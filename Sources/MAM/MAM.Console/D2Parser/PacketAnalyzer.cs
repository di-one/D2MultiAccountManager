using AmaknaProxy.API.IO;
using AmaknaProxy.API.Network;
using AmaknaProxy.API.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAM.Console.D2Parser
{
    public class PacketAnalyzer
    {
        public Action<NetworkMessage> ReceiveMessageAction;

        private BigEndianReader _buffer;
        private MessagePart _currentMessage;

        public PacketAnalyzer()
        {
            _buffer = new BigEndianReader();
        }

        public void OnGetPacket(byte[] data, int length)
        {
            if (data != null)
            {
                byte[] newData = new byte[length];
                Array.Copy(data, newData, length);
                _buffer.Add(data, 0, data.Length);
                ThreatBuffer();
            }
        }

        private void ThreatBuffer()
        {
            if (_currentMessage == null)
                _currentMessage = new MessagePart();
            long pos = _buffer.Position;

            if (_currentMessage.Build(_buffer, false))
            {
                OnDataReceived(_currentMessage);
                _currentMessage = null;
                ThreatBuffer();
            }
            //else
            //{
            //    System.Console.WriteLine("Cant build packet");
            //}
        }

        private void OnDataReceived(MessagePart part)
        {
            try
            {
                var messageDataReader = new BigEndianReader(part.Data);

                NetworkMessage message = MessageReceiver.BuildMessage((uint)part.MessageId.Value, messageDataReader);

                if (message != null)
                {
                    ReceiveMessageAction?.Invoke(message);

                    if (!message.Cancel)
                    {
                        messageDataReader.Dispose();
                        message = null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("[Network] ClientDataReceived Function -> " + ex.Message);
            }
        }
    }
}
