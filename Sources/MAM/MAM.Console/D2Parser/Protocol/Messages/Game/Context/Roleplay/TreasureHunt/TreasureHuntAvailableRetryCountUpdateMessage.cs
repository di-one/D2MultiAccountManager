namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntAvailableRetryCountUpdateMessage : NetworkMessage
	{
		public const uint Id = 2962;
		public override uint MessageId => Id;
		public sbyte questType { get; set; }
		public int availableRetryCount { get; set; }

		public TreasureHuntAvailableRetryCountUpdateMessage(sbyte questType, int availableRetryCount)
		{
			this.questType = questType;
			this.availableRetryCount = availableRetryCount;
		}

		public TreasureHuntAvailableRetryCountUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(questType);
			writer.WriteInt(availableRetryCount);
		}

		public override void Deserialize(IDataReader reader)
		{
			questType = reader.ReadSByte();
			availableRetryCount = reader.ReadInt();
		}

	}
}
