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
	public class GameFightMonsterInformations : GameFightAIInformations
	{
		public new const short Id = 975;
		public override short TypeId => Id;
		public ushort creatureGenericId { get; set; }
		public sbyte creatureGrade { get; set; }
		public short creatureLevel { get; set; }

		public GameFightMonsterInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions, ushort creatureGenericId, sbyte creatureGrade, short creatureLevel)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.spawnInfo = spawnInfo;
			this.wave = wave;
			this.stats = stats;
			this.previousPositions = previousPositions;
			this.creatureGenericId = creatureGenericId;
			this.creatureGrade = creatureGrade;
			this.creatureLevel = creatureLevel;
		}

		public GameFightMonsterInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(creatureGenericId);
			writer.WriteSByte(creatureGrade);
			writer.WriteShort(creatureLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			creatureGenericId = reader.ReadVarUShort();
			creatureGrade = reader.ReadSByte();
			creatureLevel = reader.ReadShort();
		}

	}
}
