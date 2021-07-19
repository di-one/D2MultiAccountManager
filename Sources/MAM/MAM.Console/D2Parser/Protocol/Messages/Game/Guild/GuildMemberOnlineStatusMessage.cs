namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildMemberOnlineStatusMessage : NetworkMessage
	{
		public const uint Id = 4687;
		public override uint MessageId => Id;
		public ulong memberId { get; set; }
		public bool online { get; set; }

		public GuildMemberOnlineStatusMessage(ulong memberId, bool online)
		{
			this.memberId = memberId;
			this.online = online;
		}

		public GuildMemberOnlineStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(memberId);
			writer.WriteBoolean(online);
		}

		public override void Deserialize(IDataReader reader)
		{
			memberId = reader.ReadVarULong();
			online = reader.ReadBoolean();
		}

	}
}
