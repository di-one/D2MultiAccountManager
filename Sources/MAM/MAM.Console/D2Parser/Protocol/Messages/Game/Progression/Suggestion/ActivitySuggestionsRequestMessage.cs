namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ActivitySuggestionsRequestMessage : NetworkMessage
	{
		public const uint Id = 8815;
		public override uint MessageId => Id;
		public ushort minLevel { get; set; }
		public ushort maxLevel { get; set; }
		public ushort areaId { get; set; }
		public ushort activityCategoryId { get; set; }
		public ushort nbCards { get; set; }

		public ActivitySuggestionsRequestMessage(ushort minLevel, ushort maxLevel, ushort areaId, ushort activityCategoryId, ushort nbCards)
		{
			this.minLevel = minLevel;
			this.maxLevel = maxLevel;
			this.areaId = areaId;
			this.activityCategoryId = activityCategoryId;
			this.nbCards = nbCards;
		}

		public ActivitySuggestionsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(minLevel);
			writer.WriteVarUShort(maxLevel);
			writer.WriteVarUShort(areaId);
			writer.WriteVarUShort(activityCategoryId);
			writer.WriteUShort(nbCards);
		}

		public override void Deserialize(IDataReader reader)
		{
			minLevel = reader.ReadVarUShort();
			maxLevel = reader.ReadVarUShort();
			areaId = reader.ReadVarUShort();
			activityCategoryId = reader.ReadVarUShort();
			nbCards = reader.ReadUShort();
		}

	}
}
