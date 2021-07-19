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
	public class GameFightResumeSlaveInfo
	{
		public const short Id  = 7334;
		public virtual short TypeId => Id;
		public double slaveId { get; set; }
		public IEnumerable<GameFightSpellCooldown> spellCooldowns { get; set; }
		public sbyte summonCount { get; set; }
		public sbyte bombCount { get; set; }

		public GameFightResumeSlaveInfo(double slaveId, IEnumerable<GameFightSpellCooldown> spellCooldowns, sbyte summonCount, sbyte bombCount)
		{
			this.slaveId = slaveId;
			this.spellCooldowns = spellCooldowns;
			this.summonCount = summonCount;
			this.bombCount = bombCount;
		}

		public GameFightResumeSlaveInfo() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(slaveId);
			writer.WriteShort((short)spellCooldowns.Count());
			foreach (var objectToSend in spellCooldowns)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteSByte(summonCount);
			writer.WriteSByte(bombCount);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			slaveId = reader.ReadDouble();
			var spellCooldownsCount = reader.ReadUShort();
			var spellCooldowns_ = new GameFightSpellCooldown[spellCooldownsCount];
			for (var spellCooldownsIndex = 0; spellCooldownsIndex < spellCooldownsCount; spellCooldownsIndex++)
			{
				var objectToAdd = new GameFightSpellCooldown();
				objectToAdd.Deserialize(reader);
				spellCooldowns_[spellCooldownsIndex] = objectToAdd;
			}
			spellCooldowns = spellCooldowns_;
			summonCount = reader.ReadSByte();
			bombCount = reader.ReadSByte();
		}

	}
}
