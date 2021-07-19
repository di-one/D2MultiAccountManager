namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntFlagRequestAnswerMessage : NetworkMessage
	{
		public const uint Id = 1796;
		public override uint MessageId => Id;
		public sbyte questType { get; set; }
		public sbyte result { get; set; }
		public sbyte index { get; set; }

		public TreasureHuntFlagRequestAnswerMessage(sbyte questType, sbyte result, sbyte index)
		{
			this.questType = questType;
			this.result = result;
			this.index = index;
		}

		public TreasureHuntFlagRequestAnswerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(questType);
			writer.WriteSByte(result);
			writer.WriteSByte(index);
		}

		public override void Deserialize(IDataReader reader)
		{
			questType = reader.ReadSByte();
			result = reader.ReadSByte();
			index = reader.ReadSByte();
		}

	}
}
