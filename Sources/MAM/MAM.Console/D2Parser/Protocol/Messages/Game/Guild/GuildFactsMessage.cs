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
	public class GuildFactsMessage : NetworkMessage
	{
		public const uint Id = 7964;
		public override uint MessageId => Id;
		public GuildFactSheetInformations infos { get; set; }
		public int creationDate { get; set; }
		public ushort nbTaxCollectors { get; set; }
		public IEnumerable<CharacterMinimalGuildPublicInformations> members { get; set; }

		public GuildFactsMessage(GuildFactSheetInformations infos, int creationDate, ushort nbTaxCollectors, IEnumerable<CharacterMinimalGuildPublicInformations> members)
		{
			this.infos = infos;
			this.creationDate = creationDate;
			this.nbTaxCollectors = nbTaxCollectors;
			this.members = members;
		}

		public GuildFactsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(infos.TypeId);
			infos.Serialize(writer);
			writer.WriteInt(creationDate);
			writer.WriteVarUShort(nbTaxCollectors);
			writer.WriteShort((short)members.Count());
			foreach (var objectToSend in members)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			infos = ProtocolTypeManager.GetInstance<GuildFactSheetInformations>(reader.ReadShort());
			infos.Deserialize(reader);
			creationDate = reader.ReadInt();
			nbTaxCollectors = reader.ReadVarUShort();
			var membersCount = reader.ReadUShort();
			var members_ = new CharacterMinimalGuildPublicInformations[membersCount];
			for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
			{
				var objectToAdd = new CharacterMinimalGuildPublicInformations();
				objectToAdd.Deserialize(reader);
				members_[membersIndex] = objectToAdd;
			}
			members = members_;
		}

	}
}
