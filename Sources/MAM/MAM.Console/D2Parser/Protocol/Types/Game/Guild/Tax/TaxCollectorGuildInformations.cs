namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations
	{
		public new const short Id = 8602;
		public override short TypeId => Id;
		public BasicGuildInformations guild { get; set; }

		public TaxCollectorGuildInformations(BasicGuildInformations guild)
		{
			this.guild = guild;
		}

		public TaxCollectorGuildInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			guild.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			guild = new BasicGuildInformations();
			guild.Deserialize(reader);
		}

	}
}
