namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismFightSwapRequestMessage : NetworkMessage
	{
		public const uint Id = 7166;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public ulong targetId { get; set; }

		public PrismFightSwapRequestMessage(ushort subAreaId, ulong targetId)
		{
			this.subAreaId = subAreaId;
			this.targetId = targetId;
		}

		public PrismFightSwapRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteVarULong(targetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			targetId = reader.ReadVarULong();
		}

	}
}
