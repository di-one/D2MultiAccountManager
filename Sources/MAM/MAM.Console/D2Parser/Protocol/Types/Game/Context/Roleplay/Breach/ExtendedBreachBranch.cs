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
	public class ExtendedBreachBranch : BreachBranch
	{
		public new const short Id = 5225;
		public override short TypeId => Id;
		public IEnumerable<BreachReward> rewards { get; set; }
		public int modifier { get; set; }
		public uint prize { get; set; }

		public ExtendedBreachBranch(sbyte room, int element, IEnumerable<MonsterInGroupLightInformations> bosses, double map, short score, short relativeScore, IEnumerable<MonsterInGroupLightInformations> monsters, IEnumerable<BreachReward> rewards, int modifier, uint prize)
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
		}

		public ExtendedBreachBranch() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)rewards.Count());
			foreach (var objectToSend in rewards)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteVarInt(modifier);
			writer.WriteVarUInt(prize);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var rewardsCount = reader.ReadUShort();
			var rewards_ = new BreachReward[rewardsCount];
			for (var rewardsIndex = 0; rewardsIndex < rewardsCount; rewardsIndex++)
			{
				var objectToAdd = new BreachReward();
				objectToAdd.Deserialize(reader);
				rewards_[rewardsIndex] = objectToAdd;
			}
			rewards = rewards_;
			modifier = reader.ReadVarInt();
			prize = reader.ReadVarUInt();
		}

	}
}
