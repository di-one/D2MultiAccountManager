namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapInformationsRequestMessage : NetworkMessage
	{
		public const uint Id = 4598;
		public override uint MessageId => Id;
		public double mapId { get; set; }

		public MapInformationsRequestMessage(double mapId)
		{
			this.mapId = mapId;
		}

		public MapInformationsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(mapId);
		}

		public override void Deserialize(IDataReader reader)
		{
			mapId = reader.ReadDouble();
		}

	}
}
