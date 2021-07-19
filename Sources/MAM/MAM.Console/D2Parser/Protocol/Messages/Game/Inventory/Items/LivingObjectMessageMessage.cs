namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LivingObjectMessageMessage : NetworkMessage
	{
		public const uint Id = 2732;
		public override uint MessageId => Id;
		public ushort msgId { get; set; }
		public int timeStamp { get; set; }
		public string owner { get; set; }
		public ushort objectGenericId { get; set; }

		public LivingObjectMessageMessage(ushort msgId, int timeStamp, string owner, ushort objectGenericId)
		{
			this.msgId = msgId;
			this.timeStamp = timeStamp;
			this.owner = owner;
			this.objectGenericId = objectGenericId;
		}

		public LivingObjectMessageMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(msgId);
			writer.WriteInt(timeStamp);
			writer.WriteUTF(owner);
			writer.WriteVarUShort(objectGenericId);
		}

		public override void Deserialize(IDataReader reader)
		{
			msgId = reader.ReadVarUShort();
			timeStamp = reader.ReadInt();
			owner = reader.ReadUTF();
			objectGenericId = reader.ReadVarUShort();
		}

	}
}
