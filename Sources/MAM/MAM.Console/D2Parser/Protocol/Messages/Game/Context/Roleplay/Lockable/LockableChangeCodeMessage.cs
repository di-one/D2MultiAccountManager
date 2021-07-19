namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LockableChangeCodeMessage : NetworkMessage
	{
		public const uint Id = 7756;
		public override uint MessageId => Id;
		public string code { get; set; }

		public LockableChangeCodeMessage(string code)
		{
			this.code = code;
		}

		public LockableChangeCodeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(code);
		}

		public override void Deserialize(IDataReader reader)
		{
			code = reader.ReadUTF();
		}

	}
}
