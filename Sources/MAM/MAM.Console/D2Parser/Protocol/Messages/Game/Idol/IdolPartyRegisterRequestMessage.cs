namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdolPartyRegisterRequestMessage : NetworkMessage
	{
		public const uint Id = 7517;
		public override uint MessageId => Id;
		public bool register { get; set; }

		public IdolPartyRegisterRequestMessage(bool register)
		{
			this.register = register;
		}

		public IdolPartyRegisterRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(register);
		}

		public override void Deserialize(IDataReader reader)
		{
			register = reader.ReadBoolean();
		}

	}
}
