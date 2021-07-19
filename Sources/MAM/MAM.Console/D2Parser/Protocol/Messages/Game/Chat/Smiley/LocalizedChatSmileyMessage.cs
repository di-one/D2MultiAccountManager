namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LocalizedChatSmileyMessage : ChatSmileyMessage
	{
		public new const uint Id = 8903;
		public override uint MessageId => Id;
		public ushort cellId { get; set; }

		public LocalizedChatSmileyMessage(double entityId, ushort smileyId, int accountId, ushort cellId)
		{
			this.entityId = entityId;
			this.smileyId = smileyId;
			this.accountId = accountId;
			this.cellId = cellId;
		}

		public LocalizedChatSmileyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(cellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			cellId = reader.ReadVarUShort();
		}

	}
}
