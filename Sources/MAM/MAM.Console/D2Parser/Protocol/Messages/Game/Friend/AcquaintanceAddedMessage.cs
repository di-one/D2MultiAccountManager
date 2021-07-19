namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AcquaintanceAddedMessage : NetworkMessage
	{
		public const uint Id = 4917;
		public override uint MessageId => Id;
		public AcquaintanceInformation acquaintanceAdded { get; set; }

		public AcquaintanceAddedMessage(AcquaintanceInformation acquaintanceAdded)
		{
			this.acquaintanceAdded = acquaintanceAdded;
		}

		public AcquaintanceAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(acquaintanceAdded.TypeId);
			acquaintanceAdded.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			acquaintanceAdded = ProtocolTypeManager.GetInstance<AcquaintanceInformation>(reader.ReadShort());
			acquaintanceAdded.Deserialize(reader);
		}

	}
}
