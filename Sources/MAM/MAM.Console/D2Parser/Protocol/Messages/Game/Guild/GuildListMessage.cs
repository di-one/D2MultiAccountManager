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
	public class GuildListMessage : NetworkMessage
	{
		public const uint Id = 3110;
		public override uint MessageId => Id;
		public IEnumerable<GuildInformations> guilds { get; set; }

		public GuildListMessage(IEnumerable<GuildInformations> guilds)
		{
			this.guilds = guilds;
		}

		public GuildListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)guilds.Count());
			foreach (var objectToSend in guilds)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var guildsCount = reader.ReadUShort();
			var guilds_ = new GuildInformations[guildsCount];
			for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
			{
				var objectToAdd = new GuildInformations();
				objectToAdd.Deserialize(reader);
				guilds_[guildsIndex] = objectToAdd;
			}
			guilds = guilds_;
		}

	}
}
