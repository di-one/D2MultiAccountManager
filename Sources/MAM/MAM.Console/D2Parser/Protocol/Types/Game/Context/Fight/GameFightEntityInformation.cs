namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightEntityInformation : GameFightFighterInformations
	{
		public new const short Id = 3550;
		public override short TypeId => Id;
		public sbyte entityModelId { get; set; }
		public ushort level { get; set; }
		public double masterId { get; set; }

		public GameFightEntityInformation(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions, sbyte entityModelId, ushort level, double masterId)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.spawnInfo = spawnInfo;
			this.wave = wave;
			this.stats = stats;
			this.previousPositions = previousPositions;
			this.entityModelId = entityModelId;
			this.level = level;
			this.masterId = masterId;
		}

		public GameFightEntityInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(entityModelId);
			writer.WriteVarUShort(level);
			writer.WriteDouble(masterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			entityModelId = reader.ReadSByte();
			level = reader.ReadVarUShort();
			masterId = reader.ReadDouble();
		}

	}
}
