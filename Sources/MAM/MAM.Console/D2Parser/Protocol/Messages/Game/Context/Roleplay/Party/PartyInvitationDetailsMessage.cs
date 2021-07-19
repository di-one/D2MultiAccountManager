namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyInvitationDetailsMessage : AbstractPartyMessage
	{
		public new const uint Id = 9943;
		public override uint MessageId => Id;
		public sbyte partyType { get; set; }
		public string partyName { get; set; }
		public ulong fromId { get; set; }
		public string fromName { get; set; }
		public ulong leaderId { get; set; }
		public IEnumerable<PartyInvitationMemberInformations> members { get; set; }
		public IEnumerable<PartyGuestInformations> guests { get; set; }

		public PartyInvitationDetailsMessage(uint partyId, sbyte partyType, string partyName, ulong fromId, string fromName, ulong leaderId, IEnumerable<PartyInvitationMemberInformations> members, IEnumerable<PartyGuestInformations> guests)
		{
			this.partyId = partyId;
			this.partyType = partyType;
			this.partyName = partyName;
			this.fromId = fromId;
			this.fromName = fromName;
			this.leaderId = leaderId;
			this.members = members;
			this.guests = guests;
		}

		public PartyInvitationDetailsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(partyType);
			writer.WriteUTF(partyName);
			writer.WriteVarULong(fromId);
			writer.WriteUTF(fromName);
			writer.WriteVarULong(leaderId);
			writer.WriteShort((short)members.Count());
			foreach (var objectToSend in members)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)guests.Count());
			foreach (var objectToSend in guests)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			partyType = reader.ReadSByte();
			partyName = reader.ReadUTF();
			fromId = reader.ReadVarULong();
			fromName = reader.ReadUTF();
			leaderId = reader.ReadVarULong();
			var membersCount = reader.ReadUShort();
			var members_ = new PartyInvitationMemberInformations[membersCount];
			for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<PartyInvitationMemberInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				members_[membersIndex] = objectToAdd;
			}
			members = members_;
			var guestsCount = reader.ReadUShort();
			var guests_ = new PartyGuestInformations[guestsCount];
			for (var guestsIndex = 0; guestsIndex < guestsCount; guestsIndex++)
			{
				var objectToAdd = new PartyGuestInformations();
				objectToAdd.Deserialize(reader);
				guests_[guestsIndex] = objectToAdd;
			}
			guests = guests_;
		}

	}
}
