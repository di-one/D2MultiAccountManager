namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntDigRequestAnswerFailedMessage : TreasureHuntDigRequestAnswerMessage
	{
		public new const uint Id = 9478;
		public override uint MessageId => Id;
		public sbyte wrongFlagCount { get; set; }

		public TreasureHuntDigRequestAnswerFailedMessage(sbyte questType, sbyte result, sbyte wrongFlagCount)
		{
			this.questType = questType;
			this.result = result;
			this.wrongFlagCount = wrongFlagCount;
		}

		public TreasureHuntDigRequestAnswerFailedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(wrongFlagCount);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			wrongFlagCount = reader.ReadSByte();
		}

	}
}
