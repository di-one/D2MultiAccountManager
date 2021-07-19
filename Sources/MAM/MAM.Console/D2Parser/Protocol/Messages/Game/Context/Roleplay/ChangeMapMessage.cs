namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChangeMapMessage : NetworkMessage
	{
		public const uint Id = 6904;
		public override uint MessageId => Id;
		public double mapId { get; set; }
		public bool autopilot { get; set; }

		public ChangeMapMessage(double mapId, bool autopilot)
		{
			this.mapId = mapId;
			this.autopilot = autopilot;
		}

		public ChangeMapMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(mapId);
			writer.WriteBoolean(autopilot);
		}

		public override void Deserialize(IDataReader reader)
		{
			mapId = reader.ReadDouble();
			autopilot = reader.ReadBoolean();
		}

	}
}
