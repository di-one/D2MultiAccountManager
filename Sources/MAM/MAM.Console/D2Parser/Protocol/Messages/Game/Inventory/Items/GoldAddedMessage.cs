namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GoldAddedMessage : NetworkMessage
	{
		public const uint Id = 3100;
		public override uint MessageId => Id;
		public GoldItem gold { get; set; }

		public GoldAddedMessage(GoldItem gold)
		{
			this.gold = gold;
		}

		public GoldAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			gold.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			gold = new GoldItem();
			gold.Deserialize(reader);
		}

	}
}
