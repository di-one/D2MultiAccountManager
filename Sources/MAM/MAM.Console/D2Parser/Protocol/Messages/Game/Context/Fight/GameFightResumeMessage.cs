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
	public class GameFightResumeMessage : GameFightSpectateMessage
	{
		public new const uint Id = 7575;
		public override uint MessageId => Id;
		public IEnumerable<GameFightSpellCooldown> spellCooldowns { get; set; }
		public sbyte summonCount { get; set; }
		public sbyte bombCount { get; set; }

		public GameFightResumeMessage(IEnumerable<FightDispellableEffectExtendedInformations> effects, IEnumerable<GameActionMark> marks, ushort gameTurn, int fightStart, IEnumerable<Idol> idols, IEnumerable<GameFightEffectTriggerCount> fxTriggerCounts, IEnumerable<GameFightSpellCooldown> spellCooldowns, sbyte summonCount, sbyte bombCount)
		{
			this.effects = effects;
			this.marks = marks;
			this.gameTurn = gameTurn;
			this.fightStart = fightStart;
			this.idols = idols;
			this.fxTriggerCounts = fxTriggerCounts;
			this.spellCooldowns = spellCooldowns;
			this.summonCount = summonCount;
			this.bombCount = bombCount;
		}

		public GameFightResumeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)spellCooldowns.Count());
			foreach (var objectToSend in spellCooldowns)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteSByte(summonCount);
			writer.WriteSByte(bombCount);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
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
