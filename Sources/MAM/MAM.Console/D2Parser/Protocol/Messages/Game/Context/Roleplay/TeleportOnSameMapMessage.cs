namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TeleportOnSameMapMessage : NetworkMessage
	{
		public const uint Id = 6365;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public ushort cellId { get; set; }

		public TeleportOnSameMapMessage(double targetId, ushort cellId)
		{
			this.targetId = targetId;
			this.cellId = cellId;
		}

		public TeleportOnSameMapMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(targetId);
			writer.WriteVarUShort(cellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			targetId = reader.ReadDouble();
			cellId = reader.ReadVarUShort();
		}

	}
}
