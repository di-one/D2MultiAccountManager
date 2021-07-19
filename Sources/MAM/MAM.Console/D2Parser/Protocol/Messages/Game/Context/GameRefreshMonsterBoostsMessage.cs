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
	public class GameRefreshMonsterBoostsMessage : NetworkMessage
	{
		public const uint Id = 5083;
		public override uint MessageId => Id;
		public IEnumerable<MonsterBoosts> monsterBoosts { get; set; }
		public IEnumerable<MonsterBoosts> familyBoosts { get; set; }

		public GameRefreshMonsterBoostsMessage(IEnumerable<MonsterBoosts> monsterBoosts, IEnumerable<MonsterBoosts> familyBoosts)
		{
			this.monsterBoosts = monsterBoosts;
			this.familyBoosts = familyBoosts;
		}

		public GameRefreshMonsterBoostsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)monsterBoosts.Count());
			foreach (var objectToSend in monsterBoosts)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)familyBoosts.Count());
			foreach (var objectToSend in familyBoosts)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var monsterBoostsCount = reader.ReadUShort();
			var monsterBoosts_ = new MonsterBoosts[monsterBoostsCount];
			for (var monsterBoostsIndex = 0; monsterBoostsIndex < monsterBoostsCount; monsterBoostsIndex++)
			{
				var objectToAdd = new MonsterBoosts();
				objectToAdd.Deserialize(reader);
				monsterBoosts_[monsterBoostsIndex] = objectToAdd;
			}
			monsterBoosts = monsterBoosts_;
			var familyBoostsCount = reader.ReadUShort();
			var familyBoosts_ = new MonsterBoosts[familyBoostsCount];
			for (var familyBoostsIndex = 0; familyBoostsIndex < familyBoostsCount; familyBoostsIndex++)
			{
				var objectToAdd = new MonsterBoosts();
				objectToAdd.Deserialize(reader);
				familyBoosts_[familyBoostsIndex] = objectToAdd;
			}
			familyBoosts = familyBoosts_;
		}

	}
}
