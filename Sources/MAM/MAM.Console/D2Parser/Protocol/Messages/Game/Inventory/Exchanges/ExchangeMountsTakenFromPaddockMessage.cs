namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeMountsTakenFromPaddockMessage : NetworkMessage
	{
		public const uint Id = 2648;
		public override uint MessageId => Id;
		public string name { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public string ownername { get; set; }

		public ExchangeMountsTakenFromPaddockMessage(string name, short worldX, short worldY, string ownername)
		{
			this.name = name;
			this.worldX = worldX;
			this.worldY = worldY;
			this.ownername = ownername;
		}

		public ExchangeMountsTakenFromPaddockMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(name);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteUTF(ownername);
		}

		public override void Deserialize(IDataReader reader)
		{
			name = reader.ReadUTF();
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			ownername = reader.ReadUTF();
		}

	}
}
