namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachBonusMessage : NetworkMessage
	{
		public const uint Id = 1197;
		public override uint MessageId => Id;
		public ObjectEffectInteger bonus { get; set; }

		public BreachBonusMessage(ObjectEffectInteger bonus)
		{
			this.bonus = bonus;
		}

		public BreachBonusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			bonus.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			bonus = new ObjectEffectInteger();
			bonus.Deserialize(reader);
		}

	}
}
