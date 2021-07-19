namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextReadyMessage : NetworkMessage
	{
		public const uint Id = 6149;
		public override uint MessageId => Id;
		public double mapId { get; set; }

		public GameContextReadyMessage(double mapId)
		{
			this.mapId = mapId;
		}

		public GameContextReadyMessage() { }

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
