namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildCharacsUpgradeRequestMessage : NetworkMessage
	{
		public const uint Id = 4953;
		public override uint MessageId => Id;
		public sbyte charaTypeTarget { get; set; }

		public GuildCharacsUpgradeRequestMessage(sbyte charaTypeTarget)
		{
			this.charaTypeTarget = charaTypeTarget;
		}

		public GuildCharacsUpgradeRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(charaTypeTarget);
		}

		public override void Deserialize(IDataReader reader)
		{
			charaTypeTarget = reader.ReadSByte();
		}

	}
}
