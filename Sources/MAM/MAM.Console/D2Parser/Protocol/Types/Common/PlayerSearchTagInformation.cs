namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PlayerSearchTagInformation : AbstractPlayerSearchInformation
	{
		public new const short Id = 7105;
		public override short TypeId => Id;
		public AccountTagInformation tag { get; set; }

		public PlayerSearchTagInformation(AccountTagInformation tag)
		{
			this.tag = tag;
		}

		public PlayerSearchTagInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			tag.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			tag = new AccountTagInformation();
			tag.Deserialize(reader);
		}

	}
}
