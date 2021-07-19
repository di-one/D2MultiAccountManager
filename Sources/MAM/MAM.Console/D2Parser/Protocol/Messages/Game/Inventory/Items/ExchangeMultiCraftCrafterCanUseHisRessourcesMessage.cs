namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeMultiCraftCrafterCanUseHisRessourcesMessage : NetworkMessage
	{
		public const uint Id = 1359;
		public override uint MessageId => Id;
		public bool allowed { get; set; }

		public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage(bool allowed)
		{
			this.allowed = allowed;
		}

		public ExchangeMultiCraftCrafterCanUseHisRessourcesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(allowed);
		}

		public override void Deserialize(IDataReader reader)
		{
			allowed = reader.ReadBoolean();
		}

	}
}
