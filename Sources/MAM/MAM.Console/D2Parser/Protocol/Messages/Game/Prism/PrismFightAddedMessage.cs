namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismFightAddedMessage : NetworkMessage
	{
		public const uint Id = 9746;
		public override uint MessageId => Id;
		public PrismFightersInformation fight { get; set; }

		public PrismFightAddedMessage(PrismFightersInformation fight)
		{
			this.fight = fight;
		}

		public PrismFightAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			fight.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			fight = new PrismFightersInformation();
			fight.Deserialize(reader);
		}

	}
}
