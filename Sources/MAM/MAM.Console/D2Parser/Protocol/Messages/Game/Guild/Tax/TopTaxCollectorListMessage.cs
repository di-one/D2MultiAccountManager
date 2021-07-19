namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TopTaxCollectorListMessage : AbstractTaxCollectorListMessage
	{
		public new const uint Id = 523;
		public override uint MessageId => Id;
		public bool isDungeon { get; set; }

		public TopTaxCollectorListMessage(IEnumerable<TaxCollectorInformations> informations, bool isDungeon)
		{
			this.informations = informations;
			this.isDungeon = isDungeon;
		}

		public TopTaxCollectorListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(isDungeon);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			isDungeon = reader.ReadBoolean();
		}

	}
}
