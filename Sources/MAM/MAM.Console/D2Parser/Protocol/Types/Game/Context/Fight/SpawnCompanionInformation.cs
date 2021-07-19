namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpawnCompanionInformation : SpawnInformation
	{
		public new const short Id = 1867;
		public override short TypeId => Id;
		public sbyte modelId { get; set; }
		public ushort level { get; set; }
		public double summonerId { get; set; }
		public double ownerId { get; set; }

		public SpawnCompanionInformation(sbyte modelId, ushort level, double summonerId, double ownerId)
		{
			this.modelId = modelId;
			this.level = level;
			this.summonerId = summonerId;
			this.ownerId = ownerId;
		}

		public SpawnCompanionInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(modelId);
			writer.WriteVarUShort(level);
			writer.WriteDouble(summonerId);
			writer.WriteDouble(ownerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			modelId = reader.ReadSByte();
			level = reader.ReadVarUShort();
			summonerId = reader.ReadDouble();
			ownerId = reader.ReadDouble();
		}

	}
}
