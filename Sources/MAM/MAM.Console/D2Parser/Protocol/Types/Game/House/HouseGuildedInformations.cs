namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseGuildedInformations : HouseInstanceInformations
	{
		public new const short Id = 7631;
		public override short TypeId => Id;
		public GuildInformations guildInfo { get; set; }

		public HouseGuildedInformations(bool secondHand, bool isLocked, bool hasOwner, bool isSaleLocked, int instanceId, AccountTagInformation ownerTag, long price, GuildInformations guildInfo)
		{
			this.secondHand = secondHand;
			this.isLocked = isLocked;
			this.hasOwner = hasOwner;
			this.isSaleLocked = isSaleLocked;
			this.instanceId = instanceId;
			this.ownerTag = ownerTag;
			this.price = price;
			this.guildInfo = guildInfo;
		}

		public HouseGuildedInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			guildInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guildInfo = new GuildInformations();
			guildInfo.Deserialize(reader);
		}

	}
}
