namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapNpcQuestInfo
	{
		public const short Id  = 6262;
		public virtual short TypeId => Id;
		public double mapId { get; set; }
		public IEnumerable<int> npcsIdsWithQuest { get; set; }
		public IEnumerable<GameRolePlayNpcQuestFlag> questFlags { get; set; }

		public MapNpcQuestInfo(double mapId, IEnumerable<int> npcsIdsWithQuest, IEnumerable<GameRolePlayNpcQuestFlag> questFlags)
		{
			this.mapId = mapId;
			this.npcsIdsWithQuest = npcsIdsWithQuest;
			this.questFlags = questFlags;
		}

		public MapNpcQuestInfo() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(mapId);
			writer.WriteShort((short)npcsIdsWithQuest.Count());
			foreach (var objectToSend in npcsIdsWithQuest)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteShort((short)questFlags.Count());
			foreach (var objectToSend in questFlags)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			mapId = reader.ReadDouble();
			var npcsIdsWithQuestCount = reader.ReadUShort();
			var npcsIdsWithQuest_ = new int[npcsIdsWithQuestCount];
			for (var npcsIdsWithQuestIndex = 0; npcsIdsWithQuestIndex < npcsIdsWithQuestCount; npcsIdsWithQuestIndex++)
			{
				npcsIdsWithQuest_[npcsIdsWithQuestIndex] = reader.ReadInt();
			}
			npcsIdsWithQuest = npcsIdsWithQuest_;
			var questFlagsCount = reader.ReadUShort();
			var questFlags_ = new GameRolePlayNpcQuestFlag[questFlagsCount];
			for (var questFlagsIndex = 0; questFlagsIndex < questFlagsCount; questFlagsIndex++)
			{
				var objectToAdd = new GameRolePlayNpcQuestFlag();
				objectToAdd.Deserialize(reader);
				questFlags_[questFlagsIndex] = objectToAdd;
			}
			questFlags = questFlags_;
		}

	}
}
