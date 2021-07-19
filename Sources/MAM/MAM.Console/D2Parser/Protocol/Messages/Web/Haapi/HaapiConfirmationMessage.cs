namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiConfirmationMessage : NetworkMessage
	{
		public const uint Id = 184;
		public override uint MessageId => Id;
		public ulong kamas { get; set; }
		public ulong amount { get; set; }
		public ushort rate { get; set; }
		public sbyte action { get; set; }
		public string transaction { get; set; }

		public HaapiConfirmationMessage(ulong kamas, ulong amount, ushort rate, sbyte action, string transaction)
		{
			this.kamas = kamas;
			this.amount = amount;
			this.rate = rate;
			this.action = action;
			this.transaction = transaction;
		}

		public HaapiConfirmationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(kamas);
			writer.WriteVarULong(amount);
			writer.WriteVarUShort(rate);
			writer.WriteSByte(action);
			writer.WriteUTF(transaction);
		}

		public override void Deserialize(IDataReader reader)
		{
			kamas = reader.ReadVarULong();
			amount = reader.ReadVarULong();
			rate = reader.ReadVarUShort();
			action = reader.ReadSByte();
			transaction = reader.ReadUTF();
		}

	}
}
