namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ChatSmileyMessage : NetworkMessage
	{
		public const uint Id = 7703;
		public override uint MessageId => Id;
		public double entityId { get; set; }
		public ushort smileyId { get; set; }
		public int accountId { get; set; }

		public ChatSmileyMessage(double entityId, ushort smileyId, int accountId)
		{
			this.entityId = entityId;
			this.smileyId = smileyId;
			this.accountId = accountId;
		}

		public ChatSmileyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(entityId);
			writer.WriteVarUShort(smileyId);
			writer.WriteInt(accountId);
		}

		public override void Deserialize(IDataReader reader)
		{
			entityId = reader.ReadDouble();
			smileyId = reader.ReadVarUShort();
			accountId = reader.ReadInt();
		}

	}
}
