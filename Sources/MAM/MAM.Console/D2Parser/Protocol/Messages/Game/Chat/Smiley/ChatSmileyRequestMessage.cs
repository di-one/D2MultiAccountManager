namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatSmileyRequestMessage : NetworkMessage
	{
		public const uint Id = 3196;
		public override uint MessageId => Id;
		public ushort smileyId { get; set; }

		public ChatSmileyRequestMessage(ushort smileyId)
		{
			this.smileyId = smileyId;
		}

		public ChatSmileyRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(smileyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			smileyId = reader.ReadVarUShort();
		}

	}
}
