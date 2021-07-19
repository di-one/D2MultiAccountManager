namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorDialogQuestionBasicMessage : NetworkMessage
	{
		public const uint Id = 5444;
		public override uint MessageId => Id;
		public BasicGuildInformations guildInfo { get; set; }

		public TaxCollectorDialogQuestionBasicMessage(BasicGuildInformations guildInfo)
		{
			this.guildInfo = guildInfo;
		}

		public TaxCollectorDialogQuestionBasicMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			guildInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			guildInfo = new BasicGuildInformations();
			guildInfo.Deserialize(reader);
		}

	}
}
