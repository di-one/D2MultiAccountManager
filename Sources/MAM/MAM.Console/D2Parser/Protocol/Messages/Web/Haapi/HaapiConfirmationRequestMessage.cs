namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HaapiConfirmationRequestMessage : NetworkMessage
	{
		public const uint Id = 4241;
		public override uint MessageId => Id;
		public ulong kamas { get; set; }
		public ulong ogrines { get; set; }
		public ushort rate { get; set; }
		public sbyte action { get; set; }

		public HaapiConfirmationRequestMessage(ulong kamas, ulong ogrines, ushort rate, sbyte action)
		{
			this.kamas = kamas;
			this.ogrines = ogrines;
			this.rate = rate;
			this.action = action;
		}

		public HaapiConfirmationRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(kamas);
			writer.WriteVarULong(ogrines);
			writer.WriteVarUShort(rate);
			writer.WriteSByte(action);
		}

		public override void Deserialize(IDataReader reader)
		{
			kamas = reader.ReadVarULong();
			ogrines = reader.ReadVarULong();
			rate = reader.ReadVarUShort();
			action = reader.ReadSByte();
		}

	}
}
