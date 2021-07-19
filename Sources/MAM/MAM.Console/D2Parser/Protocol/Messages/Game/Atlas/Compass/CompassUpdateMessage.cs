namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CompassUpdateMessage : NetworkMessage
	{
		public const uint Id = 5070;
		public override uint MessageId => Id;
		public sbyte type { get; set; }
		public MapCoordinates coords { get; set; }

		public CompassUpdateMessage(sbyte type, MapCoordinates coords)
		{
			this.type = type;
			this.coords = coords;
		}

		public CompassUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(type);
			writer.WriteShort(coords.TypeId);
			coords.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			type = reader.ReadSByte();
			coords = ProtocolTypeManager.GetInstance<MapCoordinates>(reader.ReadShort());
			coords.Deserialize(reader);
		}

	}
}
