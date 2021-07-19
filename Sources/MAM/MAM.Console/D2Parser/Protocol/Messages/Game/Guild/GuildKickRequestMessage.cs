namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildKickRequestMessage : NetworkMessage
	{
		public const uint Id = 7110;
		public override uint MessageId => Id;
		public ulong kickedId { get; set; }

		public GuildKickRequestMessage(ulong kickedId)
		{
			this.kickedId = kickedId;
		}

		public GuildKickRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(kickedId);
		}

		public override void Deserialize(IDataReader reader)
		{
			kickedId = reader.ReadVarULong();
		}

	}
}
