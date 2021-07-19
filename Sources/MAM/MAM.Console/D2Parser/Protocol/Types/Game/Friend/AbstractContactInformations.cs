namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractContactInformations
	{
		public const short Id  = 8922;
		public virtual short TypeId => Id;
		public int accountId { get; set; }
		public AccountTagInformation accountTag { get; set; }

		public AbstractContactInformations(int accountId, AccountTagInformation accountTag)
		{
			this.accountId = accountId;
			this.accountTag = accountTag;
		}

		public AbstractContactInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(accountId);
			accountTag.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			accountId = reader.ReadInt();
			accountTag = new AccountTagInformation();
			accountTag.Deserialize(reader);
		}

	}
}
