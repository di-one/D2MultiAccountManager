namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildMemberSetWarnOnConnectionMessage : NetworkMessage
	{
		public const uint Id = 6334;
		public override uint MessageId => Id;
		public bool enable { get; set; }

		public GuildMemberSetWarnOnConnectionMessage(bool enable)
		{
			this.enable = enable;
		}

		public GuildMemberSetWarnOnConnectionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(enable);
		}

		public override void Deserialize(IDataReader reader)
		{
			enable = reader.ReadBoolean();
		}

	}
}
