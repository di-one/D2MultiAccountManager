namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportRequestMessage : NetworkMessage
	{
		public const uint Id = 4190;
		public override uint MessageId => Id;
		public sbyte sourceType { get; set; }
		public sbyte destinationType { get; set; }
		public double mapId { get; set; }

		public TeleportRequestMessage(sbyte sourceType, sbyte destinationType, double mapId)
		{
			this.sourceType = sourceType;
			this.destinationType = destinationType;
			this.mapId = mapId;
		}

		public TeleportRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(sourceType);
			writer.WriteSByte(destinationType);
			writer.WriteDouble(mapId);
		}

		public override void Deserialize(IDataReader reader)
		{
			sourceType = reader.ReadSByte();
			destinationType = reader.ReadSByte();
			mapId = reader.ReadDouble();
		}

	}
}
