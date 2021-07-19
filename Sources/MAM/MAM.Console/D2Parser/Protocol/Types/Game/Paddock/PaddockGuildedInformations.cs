namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockGuildedInformations : PaddockBuyableInformations
	{
		public new const short Id = 5746;
		public override short TypeId => Id;
		public bool deserted { get; set; }
		public GuildInformations guildInfo { get; set; }

		public PaddockGuildedInformations(ulong price, bool locked, bool deserted, GuildInformations guildInfo)
		{
			this.price = price;
			this.locked = locked;
			this.deserted = deserted;
			this.guildInfo = guildInfo;
		}

		public PaddockGuildedInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(deserted);
			guildInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			deserted = reader.ReadBoolean();
			guildInfo = new GuildInformations();
			guildInfo.Deserialize(reader);
		}

	}
}
