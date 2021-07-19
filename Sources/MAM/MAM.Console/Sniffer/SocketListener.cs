using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Console.Sniffer
{
    public class SocketListener
    {
        public Action<byte[], int> GetPacketAction;
        public readonly ICaptureDevice Device;

        private bool _started;

        public SocketListener(ICaptureDevice device)
        {
            Device = device;
        }

        public void StartListening(string ip, int port)
        {
            if (_started == false)
            {
                _started = true;

                // Open the device for capturing
                int readTimeoutMilliseconds = 1000;
                Device.Open(mode: DeviceModes.Promiscuous | DeviceModes.DataTransferUdp | DeviceModes.NoCaptureLocal, read_timeout: readTimeoutMilliseconds);

                string filter = $"host {ip} and dst port {port}";
                Device.Filter = filter;

                Device.OnPacketArrival += OnPacketArrival;
                Device.StartCapture();
            }
            else
            {
                System.Console.WriteLine("Error : listener already started !");
            }
        }

        private void OnPacketArrival(object sender, PacketCapture e)
        {
            var device = (ICaptureDevice)sender;

            var rawPacket = e.GetPacket();

            if (rawPacket.LinkLayerType == PacketDotNet.LinkLayers.Ethernet)
            {
                var packet = PacketDotNet.Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);
                var ethernetPacket = (EthernetPacket)packet;
                var tcpPacket = PacketDotNet.TcpPacket.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

                GetPacketAction?.Invoke(packet.PayloadPacket.PayloadPacket.PayloadData, packet.PayloadPacket.PayloadPacket.PayloadData.Length);
            }
        }

        public static string GetListDevicesMessage()
        {
            var devices = LibPcapLiveDeviceList.Instance;
            int i = 0;
            string message = "";

            foreach (var dev in devices)
            {
                message += String.Format("{0}) {1} {2} \n", i, dev.Name, dev.Description);              
                i++;
            }

            return message;
        }

        public static SocketListener ListenIp(string ip, int deviceIndex)
        {
            SocketListener listener = null;


            var device = (ICaptureDevice)CaptureDeviceList.New()[deviceIndex];
            string[] address = ip.Split(':');
            string host = address[0];
            int port = int.Parse(address[1]);

            if (host == null)
            {
                System.Console.WriteLine("Ip not founded !");
                return null;
            }

            System.Console.WriteLine($"Listener created ! {ip}");
            listener = new SocketListener(device);
            listener.StartListening(host, port);


            return listener;
        }
    }
}
