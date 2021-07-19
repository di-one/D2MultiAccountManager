namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyMemberInBreachFightMessage : AbstractPartyMemberInFightMessage
	{
		public new const uint Id = 7397;
		public override uint MessageId => Id;
		public uint floor { get; set; }
		public sbyte room { get; set; }

		public PartyMemberInBreachFightMessage(uint partyId, sbyte reason, ulong memberId, int memberAccountId, string memberName, ushort fightId, short timeBeforeFightStart, uint floor, sbyte room)
		{
			this.partyId = partyId;
			this.reason = reason;
			this.memberId = memberId;
			this.memberAccountId = memberAccountId;
			this.memberName = memberName;
			this.fightId = fightId;
			this.timeBeforeFightStart = timeBeforeFightStart;
			this.floor = floor;
			this.room = room;
		}

		public PartyMemberInBreachFightMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(floor);
			writer.WriteSByte(room);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			floor = reader.ReadVarUInt();
			room = reader.ReadSByte();
		}

	}
}
