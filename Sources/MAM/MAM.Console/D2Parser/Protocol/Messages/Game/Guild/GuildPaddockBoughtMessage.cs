namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildPaddockBoughtMessage : NetworkMessage
	{
		public const uint Id = 6883;
		public override uint MessageId => Id;
		public PaddockContentInformations paddockInfo { get; set; }

		public GuildPaddockBoughtMessage(PaddockContentInformations paddockInfo)
		{
			this.paddockInfo = paddockInfo;
		}

		public GuildPaddockBoughtMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			paddockInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			paddockInfo = new PaddockContentInformations();
			paddockInfo.Deserialize(reader);
		}

	}
}
