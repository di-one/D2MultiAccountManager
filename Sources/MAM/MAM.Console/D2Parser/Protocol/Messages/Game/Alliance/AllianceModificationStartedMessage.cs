namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceModificationStartedMessage : NetworkMessage
	{
		public const uint Id = 773;
		public override uint MessageId => Id;
		public bool canChangeName { get; set; }
		public bool canChangeTag { get; set; }
		public bool canChangeEmblem { get; set; }

		public AllianceModificationStartedMessage(bool canChangeName, bool canChangeTag, bool canChangeEmblem)
		{
			this.canChangeName = canChangeName;
			this.canChangeTag = canChangeTag;
			this.canChangeEmblem = canChangeEmblem;
		}

		public AllianceModificationStartedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, canChangeName);
			flag = BooleanByteWrapper.SetFlag(flag, 1, canChangeTag);
			flag = BooleanByteWrapper.SetFlag(flag, 2, canChangeEmblem);
			writer.WriteByte(flag);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			canChangeName = BooleanByteWrapper.GetFlag(flag, 0);
			canChangeTag = BooleanByteWrapper.GetFlag(flag, 1);
			canChangeEmblem = BooleanByteWrapper.GetFlag(flag, 2);
		}

	}
}
