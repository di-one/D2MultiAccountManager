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
	public class GameFightSpectateMessage : NetworkMessage
	{
		public const uint Id = 9114;
		public override uint MessageId => Id;
		public IEnumerable<FightDispellableEffectExtendedInformations> effects { get; set; }
		public IEnumerable<GameActionMark> marks { get; set; }
		public ushort gameTurn { get; set; }
		public int fightStart { get; set; }
		public IEnumerable<Idol> idols { get; set; }
		public IEnumerable<GameFightEffectTriggerCount> fxTriggerCounts { get; set; }

		public GameFightSpectateMessage(IEnumerable<FightDispellableEffectExtendedInformations> effects, IEnumerable<GameActionMark> marks, ushort gameTurn, int fightStart, IEnumerable<Idol> idols, IEnumerable<GameFightEffectTriggerCount> fxTriggerCounts)
		{
			this.effects = effects;
			this.marks = marks;
			this.gameTurn = gameTurn;
			this.fightStart = fightStart;
			this.idols = idols;
			this.fxTriggerCounts = fxTriggerCounts;
		}

		public GameFightSpectateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)effects.Count());
			foreach (var objectToSend in effects)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)marks.Count());
			foreach (var objectToSend in marks)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteVarUShort(gameTurn);
			writer.WriteInt(fightStart);
			writer.WriteShort((short)idols.Count());
			foreach (var objectToSend in idols)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)fxTriggerCounts.Count());
			foreach (var objectToSend in fxTriggerCounts)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var effectsCount = reader.ReadUShort();
			var effects_ = new FightDispellableEffectExtendedInformations[effectsCount];
			for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
			{
				var objectToAdd = new FightDispellableEffectExtendedInformations();
				objectToAdd.Deserialize(reader);
				effects_[effectsIndex] = objectToAdd;
			}
			effects = effects_;
			var marksCount = reader.ReadUShort();
			var marks_ = new GameActionMark[marksCount];
			for (var marksIndex = 0; marksIndex < marksCount; marksIndex++)
			{
				var objectToAdd = new GameActionMark();
				objectToAdd.Deserialize(reader);
				marks_[marksIndex] = objectToAdd;
			}
			marks = marks_;
			gameTurn = reader.ReadVarUShort();
			fightStart = reader.ReadInt();
			var idolsCount = reader.ReadUShort();
			var idols_ = new Idol[idolsCount];
			for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
			{
				var objectToAdd = new Idol();
				objectToAdd.Deserialize(reader);
				idols_[idolsIndex] = objectToAdd;
			}
			idols = idols_;
			var fxTriggerCountsCount = reader.ReadUShort();
			var fxTriggerCounts_ = new GameFightEffectTriggerCount[fxTriggerCountsCount];
			for (var fxTriggerCountsIndex = 0; fxTriggerCountsIndex < fxTriggerCountsCount; fxTriggerCountsIndex++)
			{
				var objectToAdd = new GameFightEffectTriggerCount();
				objectToAdd.Deserialize(reader);
				fxTriggerCounts_[fxTriggerCountsIndex] = objectToAdd;
			}
			fxTriggerCounts = fxTriggerCounts_;
		}

	}
}
