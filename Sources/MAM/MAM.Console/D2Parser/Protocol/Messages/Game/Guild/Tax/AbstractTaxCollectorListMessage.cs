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
	public class AbstractTaxCollectorListMessage : NetworkMessage
	{
		public const uint Id = 7490;
		public override uint MessageId => Id;
		public IEnumerable<TaxCollectorInformations> informations { get; set; }

		public AbstractTaxCollectorListMessage(IEnumerable<TaxCollectorInformations> informations)
		{
			this.informations = informations;
		}

		public AbstractTaxCollectorListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)informations.Count());
			foreach (var objectToSend in informations)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var informationsCount = reader.ReadUShort();
			var informations_ = new TaxCollectorInformations[informationsCount];
			for (var informationsIndex = 0; informationsIndex < informationsCount; informationsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				informations_[informationsIndex] = objectToAdd;
			}
			informations = informations_;
		}

	}
}
