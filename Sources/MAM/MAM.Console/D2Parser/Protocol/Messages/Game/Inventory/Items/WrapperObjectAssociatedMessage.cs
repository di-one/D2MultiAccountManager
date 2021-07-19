namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class WrapperObjectAssociatedMessage : SymbioticObjectAssociatedMessage
	{
		public new const uint Id = 8396;
		public override uint MessageId => Id;

		public WrapperObjectAssociatedMessage(uint hostUID)
		{
			this.hostUID = hostUID;
		}

		public WrapperObjectAssociatedMessage() { }

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
