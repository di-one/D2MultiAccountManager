namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IgnoredDeleteRequestMessage : NetworkMessage
	{
		public const uint Id = 4288;
		public override uint MessageId => Id;
		public int accountId { get; set; }
		public bool session { get; set; }

		public IgnoredDeleteRequestMessage(int accountId, bool session)
		{
			this.accountId = accountId;
			this.session = session;
		}

		public IgnoredDeleteRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(accountId);
			writer.WriteBoolean(session);
		}

		public override void Deserialize(IDataReader reader)
		{
			accountId = reader.ReadInt();
			session = reader.ReadBoolean();
		}

	}
}
