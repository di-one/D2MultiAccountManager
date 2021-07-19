namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeMountSterilizeFromPaddockMessage : NetworkMessage
	{
		public const uint Id = 2391;
		public override uint MessageId => Id;
		public string name { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public string sterilizator { get; set; }

		public ExchangeMountSterilizeFromPaddockMessage(string name, short worldX, short worldY, string sterilizator)
		{
			this.name = name;
			this.worldX = worldX;
			this.worldY = worldY;
			this.sterilizator = sterilizator;
		}

		public ExchangeMountSterilizeFromPaddockMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(name);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteUTF(sterilizator);
		}

		public override void Deserialize(IDataReader reader)
		{
			name = reader.ReadUTF();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			sterilizator = reader.ReadUTF();
		}

	}
}
