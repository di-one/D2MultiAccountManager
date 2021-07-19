namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildLevelUpMessage : NetworkMessage
	{
		public const uint Id = 4362;
		public override uint MessageId => Id;
		public byte newLevel { get; set; }

		public GuildLevelUpMessage(byte newLevel)
		{
			this.newLevel = newLevel;
		}

		public GuildLevelUpMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteByte(newLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			newLevel = reader.ReadByte();
		}

	}
}
