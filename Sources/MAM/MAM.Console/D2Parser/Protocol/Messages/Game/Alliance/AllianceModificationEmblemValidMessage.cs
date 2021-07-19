namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceModificationEmblemValidMessage : NetworkMessage
	{
		public const uint Id = 1542;
		public override uint MessageId => Id;
		public GuildEmblem Alliancemblem { get; set; }

		public AllianceModificationEmblemValidMessage(GuildEmblem Alliancemblem)
		{
			this.Alliancemblem = Alliancemblem;
		}

		public AllianceModificationEmblemValidMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			Alliancemblem.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			Alliancemblem = new GuildEmblem();
			Alliancemblem.Deserialize(reader);
		}

	}
}
