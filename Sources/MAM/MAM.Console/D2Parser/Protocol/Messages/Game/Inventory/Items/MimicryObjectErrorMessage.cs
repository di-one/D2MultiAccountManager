namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MimicryObjectErrorMessage : SymbioticObjectErrorMessage
	{
		public new const uint Id = 809;
		public override uint MessageId => Id;
		public bool preview { get; set; }

		public MimicryObjectErrorMessage(sbyte reason, sbyte errorCode, bool preview)
		{
			this.reason = reason;
			this.errorCode = errorCode;
			this.preview = preview;
		}

		public MimicryObjectErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(preview);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			preview = reader.ReadBoolean();
		}

	}
}
