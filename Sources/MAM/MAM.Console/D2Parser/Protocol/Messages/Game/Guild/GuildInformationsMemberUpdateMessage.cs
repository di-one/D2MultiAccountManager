namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildInformationsMemberUpdateMessage : NetworkMessage
	{
		public const uint Id = 9019;
		public override uint MessageId => Id;
		public GuildMember member { get; set; }

		public GuildInformationsMemberUpdateMessage(GuildMember member)
		{
			this.member = member;
		}

		public GuildInformationsMemberUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			member.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			member = new GuildMember();
			member.Deserialize(reader);
		}

	}
}
