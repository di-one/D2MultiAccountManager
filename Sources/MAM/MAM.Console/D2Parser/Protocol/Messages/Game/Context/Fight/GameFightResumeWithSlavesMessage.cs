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
	public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
	{
		public new const uint Id = 2845;
		public override uint MessageId => Id;
		public IEnumerable<GameFightResumeSlaveInfo> slavesInfo { get; set; }

		public GameFightResumeWithSlavesMessage(IEnumerable<FightDispellableEffectExtendedInformations> effects, IEnumerable<GameActionMark> marks, ushort gameTurn, int fightStart, IEnumerable<Idol> idols, IEnumerable<GameFightEffectTriggerCount> fxTriggerCounts, IEnumerable<GameFightSpellCooldown> spellCooldowns, sbyte summonCount, sbyte bombCount, IEnumerable<GameFightResumeSlaveInfo> slavesInfo)
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
			this.slavesInfo = slavesInfo;
		}

		public GameFightResumeWithSlavesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)slavesInfo.Count());
			foreach (var objectToSend in slavesInfo)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var slavesInfoCount = reader.ReadUShort();
			var slavesInfo_ = new GameFightResumeSlaveInfo[slavesInfoCount];
			for (var slavesInfoIndex = 0; slavesInfoIndex < slavesInfoCount; slavesInfoIndex++)
			{
				var objectToAdd = new GameFightResumeSlaveInfo();
				objectToAdd.Deserialize(reader);
				slavesInfo_[slavesInfoIndex] = objectToAdd;
			}
			slavesInfo = slavesInfo_;
		}

	}
}
