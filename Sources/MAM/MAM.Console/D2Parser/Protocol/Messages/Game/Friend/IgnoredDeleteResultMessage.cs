namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IgnoredDeleteResultMessage : NetworkMessage
	{
		public const uint Id = 1421;
		public override uint MessageId => Id;
		public bool success { get; set; }
		public bool session { get; set; }
		public AccountTagInformation tag { get; set; }

		public IgnoredDeleteResultMessage(bool success, bool session, AccountTagInformation tag)
		{
			this.success = success;
			this.session = session;
			this.tag = tag;
		}

		public IgnoredDeleteResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, success);
			flag = BooleanByteWrapper.SetFlag(flag, 1, session);
			writer.WriteByte(flag);
			tag.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			success = BooleanByteWrapper.GetFlag(flag, 0);
			session = BooleanByteWrapper.GetFlag(flag, 1);
			tag = new AccountTagInformation();
			tag.Deserialize(reader);
		}

	}
}
