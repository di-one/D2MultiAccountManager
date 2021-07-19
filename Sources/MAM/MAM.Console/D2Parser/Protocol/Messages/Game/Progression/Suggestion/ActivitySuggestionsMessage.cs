namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ActivitySuggestionsMessage : NetworkMessage
	{
		public const uint Id = 7004;
		public override uint MessageId => Id;
		public IEnumerable<ushort> lockedActivitiesIds { get; set; }
		public IEnumerable<ushort> unlockedActivitiesIds { get; set; }

		public ActivitySuggestionsMessage(IEnumerable<ushort> lockedActivitiesIds, IEnumerable<ushort> unlockedActivitiesIds)
		{
			this.lockedActivitiesIds = lockedActivitiesIds;
			this.unlockedActivitiesIds = unlockedActivitiesIds;
		}

		public ActivitySuggestionsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)lockedActivitiesIds.Count());
			foreach (var objectToSend in lockedActivitiesIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)unlockedActivitiesIds.Count());
			foreach (var objectToSend in unlockedActivitiesIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var lockedActivitiesIdsCount = reader.ReadUShort();
			var lockedActivitiesIds_ = new ushort[lockedActivitiesIdsCount];
			for (var lockedActivitiesIdsIndex = 0; lockedActivitiesIdsIndex < lockedActivitiesIdsCount; lockedActivitiesIdsIndex++)
			{
				lockedActivitiesIds_[lockedActivitiesIdsIndex] = reader.ReadVarUShort();
			}
			lockedActivitiesIds = lockedActivitiesIds_;
			var unlockedActivitiesIdsCount = reader.ReadUShort();
			var unlockedActivitiesIds_ = new ushort[unlockedActivitiesIdsCount];
			for (var unlockedActivitiesIdsIndex = 0; unlockedActivitiesIdsIndex < unlockedActivitiesIdsCount; unlockedActivitiesIdsIndex++)
			{
				unlockedActivitiesIds_[unlockedActivitiesIdsIndex] = reader.ReadVarUShort();
			}
			unlockedActivitiesIds = unlockedActivitiesIds_;
		}

	}
}
