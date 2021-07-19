namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IgnoredAddRequestMessage : NetworkMessage
	{
		public const uint Id = 2703;
		public override uint MessageId => Id;
		public AbstractPlayerSearchInformation target { get; set; }
		public bool session { get; set; }

		public IgnoredAddRequestMessage(AbstractPlayerSearchInformation target, bool session)
		{
			this.target = target;
			this.session = session;
		}

		public IgnoredAddRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(target.TypeId);
			target.Serialize(writer);
			writer.WriteBoolean(session);
		}

		public override void Deserialize(IDataReader reader)
		{
			target = ProtocolTypeManager.GetInstance<AbstractPlayerSearchInformation>(reader.ReadShort());
			target.Deserialize(reader);
			session = reader.ReadBoolean();
		}

	}
}
