namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LockableCodeResultMessage : NetworkMessage
	{
		public const uint Id = 6030;
		public override uint MessageId => Id;
		public sbyte result { get; set; }

		public LockableCodeResultMessage(sbyte result)
		{
			this.result = result;
		}

		public LockableCodeResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(result);
		}

		public override void Deserialize(IDataReader reader)
		{
			result = reader.ReadSByte();
		}

	}
}
