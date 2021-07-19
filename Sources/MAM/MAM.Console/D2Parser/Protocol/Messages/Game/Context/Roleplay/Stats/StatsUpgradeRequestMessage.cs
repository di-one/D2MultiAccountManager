namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatsUpgradeRequestMessage : NetworkMessage
	{
		public const uint Id = 5276;
		public override uint MessageId => Id;
		public bool useAdditionnal { get; set; }
		public sbyte statId { get; set; }
		public ushort boostPoint { get; set; }

		public StatsUpgradeRequestMessage(bool useAdditionnal, sbyte statId, ushort boostPoint)
		{
			this.useAdditionnal = useAdditionnal;
			this.statId = statId;
			this.boostPoint = boostPoint;
		}

		public StatsUpgradeRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(useAdditionnal);
			writer.WriteSByte(statId);
			writer.WriteVarUShort(boostPoint);
		}

		public override void Deserialize(IDataReader reader)
		{
			useAdditionnal = reader.ReadBoolean();
			statId = reader.ReadSByte();
			boostPoint = reader.ReadVarUShort();
		}

	}
}
