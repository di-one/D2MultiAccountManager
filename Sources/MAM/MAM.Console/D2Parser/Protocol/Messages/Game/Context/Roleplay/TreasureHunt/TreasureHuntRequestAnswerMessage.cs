namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntRequestAnswerMessage : NetworkMessage
	{
		public const uint Id = 8383;
		public override uint MessageId => Id;
		public sbyte questType { get; set; }
		public sbyte result { get; set; }

		public TreasureHuntRequestAnswerMessage(sbyte questType, sbyte result)
		{
			this.questType = questType;
			this.result = result;
		}

		public TreasureHuntRequestAnswerMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(questType);
			writer.WriteSByte(result);
		}

		public override void Deserialize(IDataReader reader)
		{
			questType = reader.ReadSByte();
			result = reader.ReadSByte();
		}

	}
}
