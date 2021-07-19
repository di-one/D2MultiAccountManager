namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatClientPrivateMessage : ChatAbstractClientMessage
	{
		public new const uint Id = 3001;
		public override uint MessageId => Id;
		public AbstractPlayerSearchInformation receiver { get; set; }

		public ChatClientPrivateMessage(string content, AbstractPlayerSearchInformation receiver)
		{
			this.content = content;
			this.receiver = receiver;
		}

		public ChatClientPrivateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(receiver.TypeId);
			receiver.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			receiver = ProtocolTypeManager.GetInstance<AbstractPlayerSearchInformation>(reader.ReadShort());
			receiver.Deserialize(reader);
		}

	}
}
