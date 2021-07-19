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
	public class AllianceFactsMessage : NetworkMessage
	{
		public const uint Id = 3978;
		public override uint MessageId => Id;
		public AllianceFactSheetInformations infos { get; set; }
		public IEnumerable<GuildInAllianceInformations> guilds { get; set; }
		public IEnumerable<ushort> controlledSubareaIds { get; set; }
		public ulong leaderCharacterId { get; set; }
		public string leaderCharacterName { get; set; }

		public AllianceFactsMessage(AllianceFactSheetInformations infos, IEnumerable<GuildInAllianceInformations> guilds, IEnumerable<ushort> controlledSubareaIds, ulong leaderCharacterId, string leaderCharacterName)
		{
			this.infos = infos;
			this.guilds = guilds;
			this.controlledSubareaIds = controlledSubareaIds;
			this.leaderCharacterId = leaderCharacterId;
			this.leaderCharacterName = leaderCharacterName;
		}

		public AllianceFactsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(infos.TypeId);
			infos.Serialize(writer);
			writer.WriteShort((short)guilds.Count());
			foreach (var objectToSend in guilds)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)controlledSubareaIds.Count());
			foreach (var objectToSend in controlledSubareaIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteVarULong(leaderCharacterId);
			writer.WriteUTF(leaderCharacterName);
		}

		public override void Deserialize(IDataReader reader)
		{
			infos = ProtocolTypeManager.GetInstance<AllianceFactSheetInformations>(reader.ReadShort());
			infos.Deserialize(reader);
			var guildsCount = reader.ReadUShort();
			var guilds_ = new GuildInAllianceInformations[guildsCount];
			for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
			{
				var objectToAdd = new GuildInAllianceInformations();
				objectToAdd.Deserialize(reader);
				guilds_[guildsIndex] = objectToAdd;
			}
			guilds = guilds_;
			var controlledSubareaIdsCount = reader.ReadUShort();
			var controlledSubareaIds_ = new ushort[controlledSubareaIdsCount];
			for (var controlledSubareaIdsIndex = 0; controlledSubareaIdsIndex < controlledSubareaIdsCount; controlledSubareaIdsIndex++)
			{
				controlledSubareaIds_[controlledSubareaIdsIndex] = reader.ReadVarUShort();
			}
			controlledSubareaIds = controlledSubareaIds_;
			leaderCharacterId = reader.ReadVarULong();
			leaderCharacterName = reader.ReadUTF();
		}

	}
}
