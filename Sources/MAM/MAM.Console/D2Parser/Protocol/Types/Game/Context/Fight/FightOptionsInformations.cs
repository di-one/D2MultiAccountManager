namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightOptionsInformations
	{
		public const short Id  = 4321;
		public virtual short TypeId => Id;
		public bool isSecret { get; set; }
		public bool isRestrictedToPartyOnly { get; set; }
		public bool isClosed { get; set; }
		public bool isAskingForHelp { get; set; }

		public FightOptionsInformations(bool isSecret, bool isRestrictedToPartyOnly, bool isClosed, bool isAskingForHelp)
		{
			this.isSecret = isSecret;
			this.isRestrictedToPartyOnly = isRestrictedToPartyOnly;
			this.isClosed = isClosed;
			this.isAskingForHelp = isAskingForHelp;
		}

		public FightOptionsInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, isSecret);
			flag = BooleanByteWrapper.SetFlag(flag, 1, isRestrictedToPartyOnly);
			flag = BooleanByteWrapper.SetFlag(flag, 2, isClosed);
			flag = BooleanByteWrapper.SetFlag(flag, 3, isAskingForHelp);
			writer.WriteByte(flag);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			isSecret = BooleanByteWrapper.GetFlag(flag, 0);
			isRestrictedToPartyOnly = BooleanByteWrapper.GetFlag(flag, 1);
			isClosed = BooleanByteWrapper.GetFlag(flag, 2);
			isAskingForHelp = BooleanByteWrapper.GetFlag(flag, 3);
		}

	}
}
