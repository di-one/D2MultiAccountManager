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
	public class GameFightMutantInformations : GameFightFighterNamedInformations
	{
		public new const short Id = 3991;
		public override short TypeId => Id;
		public sbyte powerLevel { get; set; }

		public GameFightMutantInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions, string name, PlayerStatus status, short leagueId, int ladderPosition, bool hiddenInPrefight, sbyte powerLevel)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.spawnInfo = spawnInfo;
			this.wave = wave;
			this.stats = stats;
			this.previousPositions = previousPositions;
			this.name = name;
			this.status = status;
			this.leagueId = leagueId;
			this.ladderPosition = ladderPosition;
			this.hiddenInPrefight = hiddenInPrefight;
			this.powerLevel = powerLevel;
		}

		public GameFightMutantInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(powerLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			powerLevel = reader.ReadSByte();
		}

	}
}
