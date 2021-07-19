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
	public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
	{
		public new const short Id = 9829;
		public override short TypeId => Id;
		public ActorAlignmentInformations alignmentInfos { get; set; }

		public GameFightMonsterWithAlignmentInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions, ushort creatureGenericId, sbyte creatureGrade, short creatureLevel, ActorAlignmentInformations alignmentInfos)
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
			this.alignmentInfos = alignmentInfos;
		}

		public GameFightMonsterWithAlignmentInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			alignmentInfos.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			alignmentInfos = new ActorAlignmentInformations();
			alignmentInfos.Deserialize(reader);
		}

	}
}
