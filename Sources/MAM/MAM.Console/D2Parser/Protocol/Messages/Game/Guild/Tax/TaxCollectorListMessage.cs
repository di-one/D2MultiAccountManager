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
	public class TaxCollectorListMessage : AbstractTaxCollectorListMessage
	{
		public new const uint Id = 7528;
		public override uint MessageId => Id;
		public sbyte nbcollectorMax { get; set; }
		public IEnumerable<TaxCollectorFightersInformation> fightersInformations { get; set; }
		public sbyte infoType { get; set; }

		public TaxCollectorListMessage(IEnumerable<TaxCollectorInformations> informations, sbyte nbcollectorMax, IEnumerable<TaxCollectorFightersInformation> fightersInformations, sbyte infoType)
		{
			this.informations = informations;
			this.nbcollectorMax = nbcollectorMax;
			this.fightersInformations = fightersInformations;
			this.infoType = infoType;
		}

		public TaxCollectorListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(nbcollectorMax);
			writer.WriteShort((short)fightersInformations.Count());
			foreach (var objectToSend in fightersInformations)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteSByte(infoType);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			nbcollectorMax = reader.ReadSByte();
			var fightersInformationsCount = reader.ReadUShort();
			var fightersInformations_ = new TaxCollectorFightersInformation[fightersInformationsCount];
			for (var fightersInformationsIndex = 0; fightersInformationsIndex < fightersInformationsCount; fightersInformationsIndex++)
			{
				var objectToAdd = new TaxCollectorFightersInformation();
				objectToAdd.Deserialize(reader);
				fightersInformations_[fightersInformationsIndex] = objectToAdd;
			}
			fightersInformations = fightersInformations_;
			infoType = reader.ReadSByte();
		}

	}
}
