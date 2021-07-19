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
	public class FightResultPlayerListEntry : FightResultFighterListEntry
	{
		public new const short Id = 7134;
		public override short TypeId => Id;
		public ushort level { get; set; }
		public IEnumerable<FightResultAdditionalData> additional { get; set; }

		public FightResultPlayerListEntry(ushort outcome, sbyte wave, FightLoot rewards, double objectId, bool alive, ushort level, IEnumerable<FightResultAdditionalData> additional)
		{
			this.outcome = outcome;
			this.wave = wave;
			this.rewards = rewards;
			this.objectId = objectId;
			this.alive = alive;
			this.level = level;
			this.additional = additional;
		}

		public FightResultPlayerListEntry() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(level);
			writer.WriteShort((short)additional.Count());
			foreach (var objectToSend in additional)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			level = reader.ReadVarUShort();
			var additionalCount = reader.ReadUShort();
			var additional_ = new FightResultAdditionalData[additionalCount];
			for (var additionalIndex = 0; additionalIndex < additionalCount; additionalIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<FightResultAdditionalData>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				additional_[additionalIndex] = objectToAdd;
			}
			additional = additional_;
		}

	}
}
