namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : NetworkMessage
	{
		public const uint Id = 1142;
		public override uint MessageId => Id;
		public bool allow { get; set; }

		public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(bool allow)
		{
			this.allow = allow;
		}

		public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(allow);
		}

		public override void Deserialize(IDataReader reader)
		{
			allow = reader.ReadBoolean();
		}

	}
}
