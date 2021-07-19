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
	public class ExtendedLockedBreachBranch : ExtendedBreachBranch
	{
		public new const short Id = 1195;
		public override short TypeId => Id;
		public uint unlockPrice { get; set; }

		public ExtendedLockedBreachBranch(sbyte room, int element, IEnumerable<MonsterInGroupLightInformations> bosses, double map, short score, short relativeScore, IEnumerable<MonsterInGroupLightInformations> monsters, IEnumerable<BreachReward> rewards, int modifier, uint prize, uint unlockPrice)
		{
			this.room = room;
			this.element = element;
			this.bosses = bosses;
			this.map = map;
			this.score = score;
			this.relativeScore = relativeScore;
			this.monsters = monsters;
			this.rewards = rewards;
			this.modifier = modifier;
			this.prize = prize;
			this.unlockPrice = unlockPrice;
		}

		public ExtendedLockedBreachBranch() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(unlockPrice);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			unlockPrice = reader.ReadVarUInt();
		}

	}
}
