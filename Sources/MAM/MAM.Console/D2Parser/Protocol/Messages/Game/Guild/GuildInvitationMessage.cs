namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInvitationMessage : NetworkMessage
	{
		public const uint Id = 2571;
		public override uint MessageId => Id;
		public ulong targetId { get; set; }

		public GuildInvitationMessage(ulong targetId)
		{
			this.targetId = targetId;
		}

		public GuildInvitationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(targetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			targetId = reader.ReadVarULong();
		}

	}
}
