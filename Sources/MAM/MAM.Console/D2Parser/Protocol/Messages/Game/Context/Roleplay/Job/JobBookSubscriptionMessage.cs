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
	public class JobBookSubscriptionMessage : NetworkMessage
	{
		public const uint Id = 2795;
		public override uint MessageId => Id;
		public IEnumerable<JobBookSubscription> subscriptions { get; set; }

		public JobBookSubscriptionMessage(IEnumerable<JobBookSubscription> subscriptions)
		{
			this.subscriptions = subscriptions;
		}

		public JobBookSubscriptionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)subscriptions.Count());
			foreach (var objectToSend in subscriptions)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var subscriptionsCount = reader.ReadUShort();
			var subscriptions_ = new JobBookSubscription[subscriptionsCount];
			for (var subscriptionsIndex = 0; subscriptionsIndex < subscriptionsCount; subscriptionsIndex++)
			{
				var objectToAdd = new JobBookSubscription();
				objectToAdd.Deserialize(reader);
				subscriptions_[subscriptionsIndex] = objectToAdd;
			}
			subscriptions = subscriptions_;
		}

	}
}
