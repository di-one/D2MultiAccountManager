namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntFlagRemoveRequestMessage : NetworkMessage
	{
		public const uint Id = 3615;
		public override uint MessageId => Id;
		public sbyte questType { get; set; }
		public sbyte index { get; set; }

		public TreasureHuntFlagRemoveRequestMessage(sbyte questType, sbyte index)
		{
			this.questType = questType;
			this.index = index;
		}

		public TreasureHuntFlagRemoveRequestMessage() { }

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
