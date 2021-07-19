namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildModificationNameValidMessage : NetworkMessage
	{
		public const uint Id = 268;
		public override uint MessageId => Id;
		public string guildName { get; set; }

		public GuildModificationNameValidMessage(string guildName)
		{
			this.guildName = guildName;
		}

		public GuildModificationNameValidMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(guildName);
		}

		public override void Deserialize(IDataReader reader)
		{
			guildName = reader.ReadUTF();
		}

	}
}
