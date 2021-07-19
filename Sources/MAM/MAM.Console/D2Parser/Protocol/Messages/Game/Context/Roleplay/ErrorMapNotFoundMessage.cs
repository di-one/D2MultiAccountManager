namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ErrorMapNotFoundMessage : NetworkMessage
	{
		public const uint Id = 1598;
		public override uint MessageId => Id;
		public double mapId { get; set; }

		public ErrorMapNotFoundMessage(double mapId)
		{
			this.mapId = mapId;
		}

		public ErrorMapNotFoundMessage() { }

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
