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
	public class GuildInformationsMembersMessage : NetworkMessage
	{
		public const uint Id = 1603;
		public override uint MessageId => Id;
		public IEnumerable<GuildMember> members { get; set; }

		public GuildInformationsMembersMessage(IEnumerable<GuildMember> members)
		{
			this.members = members;
		}

		public GuildInformationsMembersMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)members.Count());
			foreach (var objectToSend in members)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var membersCount = reader.ReadUShort();
			var members_ = new GuildMember[membersCount];
			for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
			{
				var objectToAdd = new GuildMember();
				objectToAdd.Deserialize(reader);
				members_[membersIndex] = objectToAdd;
			}
			members = members_;
		}

	}
}
