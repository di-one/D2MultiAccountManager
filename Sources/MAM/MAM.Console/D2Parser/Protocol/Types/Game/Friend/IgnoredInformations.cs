namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IgnoredInformations : AbstractContactInformations
	{
		public new const short Id = 4223;
		public override short TypeId => Id;

		public IgnoredInformations(int accountId, AccountTagInformation accountTag)
		{
			this.accountId = accountId;
			this.accountTag = accountTag;
		}

		public IgnoredInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
