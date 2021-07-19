namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class WrapperObjectErrorMessage : SymbioticObjectErrorMessage
	{
		public new const uint Id = 4826;
		public override uint MessageId => Id;

		public WrapperObjectErrorMessage(sbyte reason, sbyte errorCode)
		{
			this.reason = reason;
			this.errorCode = errorCode;
		}

		public WrapperObjectErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
