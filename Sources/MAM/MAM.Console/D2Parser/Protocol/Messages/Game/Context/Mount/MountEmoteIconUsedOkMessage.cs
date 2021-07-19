namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountEmoteIconUsedOkMessage : NetworkMessage
	{
		public const uint Id = 5738;
		public override uint MessageId => Id;
		public int mountId { get; set; }
		public sbyte reactionType { get; set; }

		public MountEmoteIconUsedOkMessage(int mountId, sbyte reactionType)
		{
			this.mountId = mountId;
			this.reactionType = reactionType;
		}

		public MountEmoteIconUsedOkMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarInt(mountId);
			writer.WriteSByte(reactionType);
		}

		public override void Deserialize(IDataReader reader)
		{
			mountId = reader.ReadVarInt();
			reactionType = reader.ReadSByte();
		}

	}
}
