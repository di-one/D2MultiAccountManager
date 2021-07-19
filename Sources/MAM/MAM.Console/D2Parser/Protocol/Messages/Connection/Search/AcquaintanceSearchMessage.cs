namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AcquaintanceSearchMessage : NetworkMessage
	{
		public const uint Id = 2556;
		public override uint MessageId => Id;
		public AccountTagInformation tag { get; set; }

		public AcquaintanceSearchMessage(AccountTagInformation tag)
		{
			this.tag = tag;
		}

		public AcquaintanceSearchMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			tag.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			tag = new AccountTagInformation();
			tag.Deserialize(reader);
		}

	}
}
