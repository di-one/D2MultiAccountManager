namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameMapNoMovementMessage : NetworkMessage
	{
		public const uint Id = 9231;
		public override uint MessageId => Id;
		public short cellX { get; set; }
		public short cellY { get; set; }

		public GameMapNoMovementMessage(short cellX, short cellY)
		{
			this.cellX = cellX;
			this.cellY = cellY;
		}

		public GameMapNoMovementMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(cellX);
			writer.WriteShort(cellY);
		}

		public override void Deserialize(IDataReader reader)
		{
			cellX = reader.ReadShort();
			cellY = reader.ReadShort();
		}

	}
}
