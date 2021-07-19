namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SymbioticObjectErrorMessage : ObjectErrorMessage
	{
		public new const uint Id = 4539;
		public override uint MessageId => Id;
		public sbyte errorCode { get; set; }

		public SymbioticObjectErrorMessage(sbyte reason, sbyte errorCode)
		{
			this.reason = reason;
			this.errorCode = errorCode;
		}

		public SymbioticObjectErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(errorCode);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			errorCode = reader.ReadSByte();
		}

	}
}
