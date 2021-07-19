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
	public class GameFightCharacterInformations : GameFightFighterNamedInformations
	{
		public new const short Id = 5141;
		public override short TypeId => Id;
		public ushort level { get; set; }
		public ActorAlignmentInformations alignmentInfos { get; set; }
		public sbyte breed { get; set; }
		public bool sex { get; set; }

		public GameFightCharacterInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions, string name, PlayerStatus status, short leagueId, int ladderPosition, bool hiddenInPrefight, ushort level, ActorAlignmentInformations alignmentInfos, sbyte breed, bool sex)
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
			this.level = level;
			this.alignmentInfos = alignmentInfos;
			this.breed = breed;
			this.sex = sex;
		}

		public GameFightCharacterInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(level);
			alignmentInfos.Serialize(writer);
			writer.WriteSByte(breed);
			writer.WriteBoolean(sex);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			level = reader.ReadVarUShort();
			alignmentInfos = new ActorAlignmentInformations();
			alignmentInfos.Deserialize(reader);
			breed = reader.ReadSByte();
			sex = reader.ReadBoolean();
		}

	}
}
