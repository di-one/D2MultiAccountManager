namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildMemberLeavingMessage : NetworkMessage
	{
		public const uint Id = 1501;
		public override uint MessageId => Id;
		public bool kicked { get; set; }
		public ulong memberId { get; set; }

		public GuildMemberLeavingMessage(bool kicked, ulong memberId)
		{
			this.kicked = kicked;
			this.memberId = memberId;
		}

		public GuildMemberLeavingMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(kicked);
			writer.WriteVarULong(memberId);
		}

		public override void Deserialize(IDataReader reader)
		{
			kicked = reader.ReadBoolean();
			memberId = reader.ReadVarULong();
		}

	}
}
