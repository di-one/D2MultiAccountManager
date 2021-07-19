namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntFlagRequestMessage : NetworkMessage
	{
		public const uint Id = 1528;
		public override uint MessageId => Id;
		public sbyte questType { get; set; }
		public sbyte index { get; set; }

		public TreasureHuntFlagRequestMessage(sbyte questType, sbyte index)
		{
			this.questType = questType;
			this.index = index;
		}

		public TreasureHuntFlagRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(questType);
			writer.WriteSByte(index);
		}

		public override void Deserialize(IDataReader reader)
		{
			questType = reader.ReadSByte();
			index = reader.ReadSByte();
		}

	}
}
