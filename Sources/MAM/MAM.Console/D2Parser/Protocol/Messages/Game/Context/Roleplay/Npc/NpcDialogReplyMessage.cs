namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NpcDialogReplyMessage : NetworkMessage
	{
		public const uint Id = 6189;
		public override uint MessageId => Id;
		public uint replyId { get; set; }

		public NpcDialogReplyMessage(uint replyId)
		{
			this.replyId = replyId;
		}

		public NpcDialogReplyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(replyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			replyId = reader.ReadVarUInt();
		}

	}
}
