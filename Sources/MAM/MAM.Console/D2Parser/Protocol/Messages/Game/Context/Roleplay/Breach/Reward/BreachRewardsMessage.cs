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
	public class BreachRewardsMessage : NetworkMessage
	{
		public const uint Id = 7161;
		public override uint MessageId => Id;
		public IEnumerable<BreachReward> rewards { get; set; }

		public BreachRewardsMessage(IEnumerable<BreachReward> rewards)
		{
			this.rewards = rewards;
		}

		public BreachRewardsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)rewards.Count());
			foreach (var objectToSend in rewards)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var rewardsCount = reader.ReadUShort();
			var rewards_ = new BreachReward[rewardsCount];
			for (var rewardsIndex = 0; rewardsIndex < rewardsCount; rewardsIndex++)
			{
				var objectToAdd = new BreachReward();
				objectToAdd.Deserialize(reader);
				rewards_[rewardsIndex] = objectToAdd;
			}
			rewards = rewards_;
		}

	}
}
