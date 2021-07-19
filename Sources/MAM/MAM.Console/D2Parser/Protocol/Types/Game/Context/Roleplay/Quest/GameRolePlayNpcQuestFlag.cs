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
	public class GameRolePlayNpcQuestFlag
	{
		public const short Id  = 8580;
		public virtual short TypeId => Id;
		public IEnumerable<ushort> questsToValidId { get; set; }
		public IEnumerable<ushort> questsToStartId { get; set; }

		public GameRolePlayNpcQuestFlag(IEnumerable<ushort> questsToValidId, IEnumerable<ushort> questsToStartId)
		{
			this.questsToValidId = questsToValidId;
			this.questsToStartId = questsToStartId;
		}

		public GameRolePlayNpcQuestFlag() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)questsToValidId.Count());
			foreach (var objectToSend in questsToValidId)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)questsToStartId.Count());
			foreach (var objectToSend in questsToStartId)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var questsToValidIdCount = reader.ReadUShort();
			var questsToValidId_ = new ushort[questsToValidIdCount];
			for (var questsToValidIdIndex = 0; questsToValidIdIndex < questsToValidIdCount; questsToValidIdIndex++)
			{
				questsToValidId_[questsToValidIdIndex] = reader.ReadVarUShort();
			}
			questsToValidId = questsToValidId_;
			var questsToStartIdCount = reader.ReadUShort();
			var questsToStartId_ = new ushort[questsToStartIdCount];
			for (var questsToStartIdIndex = 0; questsToStartIdIndex < questsToStartIdCount; questsToStartIdIndex++)
			{
				questsToStartId_[questsToStartIdIndex] = reader.ReadVarUShort();
			}
			questsToStartId = questsToStartId_;
		}

	}
}
