namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SubscriptionZoneMessage : NetworkMessage
	{
		public const uint Id = 7757;
		public override uint MessageId => Id;
		public bool active { get; set; }

		public SubscriptionZoneMessage(bool active)
		{
			this.active = active;
		}

		public SubscriptionZoneMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(active);
		}

		public override void Deserialize(IDataReader reader)
		{
			active = reader.ReadBoolean();
		}

	}
}
