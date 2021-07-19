namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractPartyMemberInFightMessage : AbstractPartyMessage
	{
		public new const uint Id = 3878;
		public override uint MessageId => Id;
		public sbyte reason { get; set; }
		public ulong memberId { get; set; }
		public int memberAccountId { get; set; }
		public string memberName { get; set; }
		public ushort fightId { get; set; }
		public short timeBeforeFightStart { get; set; }

		public AbstractPartyMemberInFightMessage(uint partyId, sbyte reason, ulong memberId, int memberAccountId, string memberName, ushort fightId, short timeBeforeFightStart)
		{
			this.partyId = partyId;
			this.reason = reason;
			this.memberId = memberId;
			this.memberAccountId = memberAccountId;
			this.memberName = memberName;
			this.fightId = fightId;
			this.timeBeforeFightStart = timeBeforeFightStart;
		}

		public AbstractPartyMemberInFightMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(reason);
			writer.WriteVarULong(memberId);
			writer.WriteInt(memberAccountId);
			writer.WriteUTF(memberName);
			writer.WriteVarUShort(fightId);
			writer.WriteVarShort(timeBeforeFightStart);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			reason = reader.ReadSByte();
			memberId = reader.ReadVarULong();
			memberAccountId = reader.ReadInt();
			memberName = reader.ReadUTF();
			fightId = reader.ReadVarUShort();
			timeBeforeFightStart = reader.ReadVarShort();
		}

	}
}
