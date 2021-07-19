namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildModificationStartedMessage : NetworkMessage
	{
		public const uint Id = 8169;
		public override uint MessageId => Id;
		public bool canChangeName { get; set; }
		public bool canChangeEmblem { get; set; }

		public GuildModificationStartedMessage(bool canChangeName, bool canChangeEmblem)
		{
			this.canChangeName = canChangeName;
			this.canChangeEmblem = canChangeEmblem;
		}

		public GuildModificationStartedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, canChangeName);
			flag = BooleanByteWrapper.SetFlag(flag, 1, canChangeEmblem);
			writer.WriteByte(flag);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			canChangeName = BooleanByteWrapper.GetFlag(flag, 0);
			canChangeEmblem = BooleanByteWrapper.GetFlag(flag, 1);
		}

	}
}
