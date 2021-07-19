namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdolSelectErrorMessage : NetworkMessage
	{
		public const uint Id = 2333;
		public override uint MessageId => Id;
		public bool activate { get; set; }
		public bool party { get; set; }
		public sbyte reason { get; set; }
		public ushort idolId { get; set; }

		public IdolSelectErrorMessage(bool activate, bool party, sbyte reason, ushort idolId)
		{
			this.activate = activate;
			this.party = party;
			this.reason = reason;
			this.idolId = idolId;
		}

		public IdolSelectErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, activate);
			flag = BooleanByteWrapper.SetFlag(flag, 1, party);
			writer.WriteByte(flag);
			writer.WriteSByte(reason);
			writer.WriteVarUShort(idolId);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			activate = BooleanByteWrapper.GetFlag(flag, 0);
			party = BooleanByteWrapper.GetFlag(flag, 1);
			reason = reader.ReadSByte();
			idolId = reader.ReadVarUShort();
		}

	}
}
