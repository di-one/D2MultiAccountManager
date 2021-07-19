namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicWhoIsNoMatchMessage : NetworkMessage
	{
		public const uint Id = 2995;
		public override uint MessageId => Id;
		public AbstractPlayerSearchInformation target { get; set; }

		public BasicWhoIsNoMatchMessage(AbstractPlayerSearchInformation target)
		{
			this.target = target;
		}

		public BasicWhoIsNoMatchMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(target.TypeId);
			target.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			target = ProtocolTypeManager.GetInstance<AbstractPlayerSearchInformation>(reader.ReadShort());
			target.Deserialize(reader);
		}

	}
}
