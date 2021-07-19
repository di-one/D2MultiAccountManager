namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeOnHumanVendorRequestMessage : NetworkMessage
	{
		public const uint Id = 5800;
		public override uint MessageId => Id;
		public ulong humanVendorId { get; set; }
		public ushort humanVendorCell { get; set; }

		public ExchangeOnHumanVendorRequestMessage(ulong humanVendorId, ushort humanVendorCell)
		{
			this.humanVendorId = humanVendorId;
			this.humanVendorCell = humanVendorCell;
		}

		public ExchangeOnHumanVendorRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(humanVendorId);
			writer.WriteVarUShort(humanVendorCell);
		}

		public override void Deserialize(IDataReader reader)
		{
			humanVendorId = reader.ReadVarULong();
			humanVendorCell = reader.ReadVarUShort();
		}

	}
}
