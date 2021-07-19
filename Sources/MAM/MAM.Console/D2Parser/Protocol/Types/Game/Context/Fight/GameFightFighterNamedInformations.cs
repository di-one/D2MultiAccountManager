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
	public class GameFightFighterNamedInformations : GameFightFighterInformations
	{
		public new const short Id = 3910;
		public override short TypeId => Id;
		public string name { get; set; }
		public PlayerStatus status { get; set; }
		public short leagueId { get; set; }
		public int ladderPosition { get; set; }
		public bool hiddenInPrefight { get; set; }

		public GameFightFighterNamedInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions, string name, PlayerStatus status, short leagueId, int ladderPosition, bool hiddenInPrefight)
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
		}

		public GameFightFighterNamedInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
			status.Serialize(writer);
			writer.WriteVarShort(leagueId);
			writer.WriteInt(ladderPosition);
			writer.WriteBoolean(hiddenInPrefight);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
			status = new PlayerStatus();
			status.Deserialize(reader);
			leagueId = reader.ReadVarShort();
			ladderPosition = reader.ReadInt();
			hiddenInPrefight = reader.ReadBoolean();
		}

	}
}
