namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyMemberInStandardFightMessage : AbstractPartyMemberInFightMessage
	{
		public new const uint Id = 8272;
		public override uint MessageId => Id;
		public MapCoordinatesExtended fightMap { get; set; }

		public PartyMemberInStandardFightMessage(uint partyId, sbyte reason, ulong memberId, int memberAccountId, string memberName, ushort fightId, short timeBeforeFightStart, MapCoordinatesExtended fightMap)
		{
			this.partyId = partyId;
			this.reason = reason;
			this.memberId = memberId;
			this.memberAccountId = memberAccountId;
			this.memberName = memberName;
			this.fightId = fightId;
			this.timeBeforeFightStart = timeBeforeFightStart;
			this.fightMap = fightMap;
		}

		public PartyMemberInStandardFightMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			fightMap.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			fightMap = new MapCoordinatesExtended();
			fightMap.Deserialize(reader);
		}

	}
}
