namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeMountFreeFromPaddockMessage : NetworkMessage
	{
		public const uint Id = 7046;
		public override uint MessageId => Id;
		public string name { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public string liberator { get; set; }

		public ExchangeMountFreeFromPaddockMessage(string name, short worldX, short worldY, string liberator)
		{
			this.name = name;
			this.worldX = worldX;
			this.worldY = worldY;
			this.liberator = liberator;
		}

		public ExchangeMountFreeFromPaddockMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(name);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteUTF(liberator);
		}

		public override void Deserialize(IDataReader reader)
		{
			name = reader.ReadUTF();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			liberator = reader.ReadUTF();
		}

	}
}
