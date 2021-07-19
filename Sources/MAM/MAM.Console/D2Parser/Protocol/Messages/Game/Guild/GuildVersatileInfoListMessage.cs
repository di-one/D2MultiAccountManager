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
	public class GuildVersatileInfoListMessage : NetworkMessage
	{
		public const uint Id = 4534;
		public override uint MessageId => Id;
		public IEnumerable<GuildVersatileInformations> guilds { get; set; }

		public GuildVersatileInfoListMessage(IEnumerable<GuildVersatileInformations> guilds)
		{
			this.guilds = guilds;
		}

		public GuildVersatileInfoListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)guilds.Count());
			foreach (var objectToSend in guilds)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var guildsCount = reader.ReadUShort();
			var guilds_ = new GuildVersatileInformations[guildsCount];
			for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<GuildVersatileInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				guilds_[guildsIndex] = objectToAdd;
			}
			guilds = guilds_;
		}

	}
}
