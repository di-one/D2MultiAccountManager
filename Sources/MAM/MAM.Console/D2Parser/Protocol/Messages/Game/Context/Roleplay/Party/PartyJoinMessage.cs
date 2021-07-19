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
	public class PartyJoinMessage : AbstractPartyMessage
	{
		public new const uint Id = 1379;
		public override uint MessageId => Id;
		public sbyte partyType { get; set; }
		public ulong partyLeaderId { get; set; }
		public sbyte maxParticipants { get; set; }
		public IEnumerable<PartyMemberInformations> members { get; set; }
		public IEnumerable<PartyGuestInformations> guests { get; set; }
		public bool restricted { get; set; }
		public string partyName { get; set; }

		public PartyJoinMessage(uint partyId, sbyte partyType, ulong partyLeaderId, sbyte maxParticipants, IEnumerable<PartyMemberInformations> members, IEnumerable<PartyGuestInformations> guests, bool restricted, string partyName)
		{
			this.partyId = partyId;
			this.partyType = partyType;
			this.partyLeaderId = partyLeaderId;
			this.maxParticipants = maxParticipants;
			this.members = members;
			this.guests = guests;
			this.restricted = restricted;
			this.partyName = partyName;
		}

		public PartyJoinMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(partyType);
			writer.WriteVarULong(partyLeaderId);
			writer.WriteSByte(maxParticipants);
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
			writer.WriteBoolean(restricted);
			writer.WriteUTF(partyName);
		}

		public override void Deserialize(IDataReader reader)
		{

			base.Deserialize(reader);
			partyType = reader.ReadSByte();
			partyLeaderId = reader.ReadVarULong();
			maxParticipants = reader.ReadSByte();
			var membersCount = reader.ReadUShort();
			var members_ = new PartyMemberInformations[membersCount];
			for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
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
			restricted = reader.ReadBoolean();
			partyName = reader.ReadUTF();
		}

	}
}
