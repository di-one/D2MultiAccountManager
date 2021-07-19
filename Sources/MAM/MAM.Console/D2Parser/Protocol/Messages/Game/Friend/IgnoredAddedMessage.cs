namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IgnoredAddedMessage : NetworkMessage
	{
		public const uint Id = 8626;
		public override uint MessageId => Id;
		public IgnoredInformations ignoreAdded { get; set; }
		public bool session { get; set; }

		public IgnoredAddedMessage(IgnoredInformations ignoreAdded, bool session)
		{
			this.ignoreAdded = ignoreAdded;
			this.session = session;
		}

		public IgnoredAddedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(ignoreAdded.TypeId);
			ignoreAdded.Serialize(writer);
			writer.WriteBoolean(session);
		}

		public override void Deserialize(IDataReader reader)
		{
			ignoreAdded = ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
			ignoreAdded.Deserialize(reader);
			session = reader.ReadBoolean();
		}

	}
}
