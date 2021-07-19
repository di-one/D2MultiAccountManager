namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TitleSelectErrorMessage : NetworkMessage
	{
		public const uint Id = 1215;
		public override uint MessageId => Id;
		public sbyte reason { get; set; }

		public TitleSelectErrorMessage(sbyte reason)
		{
			this.reason = reason;
		}

		public TitleSelectErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(reason);
		}

		public override void Deserialize(IDataReader reader)
		{
			reason = reader.ReadSByte();
		}

	}
}
