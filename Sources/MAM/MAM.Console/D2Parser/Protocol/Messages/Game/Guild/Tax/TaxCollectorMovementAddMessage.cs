namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorMovementAddMessage : NetworkMessage
	{
		public const uint Id = 5745;
		public override uint MessageId => Id;
		public TaxCollectorInformations informations { get; set; }

		public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
		{
			this.informations = informations;
		}

		public TaxCollectorMovementAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(informations.TypeId);
			informations.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			informations = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
			informations.Deserialize(reader);
		}

	}
}
