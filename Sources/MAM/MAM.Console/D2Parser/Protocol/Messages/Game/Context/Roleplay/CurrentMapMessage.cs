namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CurrentMapMessage : NetworkMessage
	{
		public const uint Id = 3437;
		public override uint MessageId => Id;
		public double mapId { get; set; }
		public string mapKey { get; set; }

		public CurrentMapMessage(double mapId, string mapKey)
		{
			this.mapId = mapId;
			this.mapKey = mapKey;
		}

		public CurrentMapMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(mapId);
			writer.WriteUTF(mapKey);
		}

		public override void Deserialize(IDataReader reader)
		{
			mapId = reader.ReadDouble();
			mapKey = reader.ReadUTF();
		}

	}
}
