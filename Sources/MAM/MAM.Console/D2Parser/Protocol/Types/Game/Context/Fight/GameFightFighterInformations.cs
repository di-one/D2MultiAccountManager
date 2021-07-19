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
	public class GameFightFighterInformations : GameContextActorInformations
	{
		public new const short Id = 8684;
		public override short TypeId => Id;
		public GameContextBasicSpawnInformation spawnInfo { get; set; }
		public sbyte wave { get; set; }
		public GameFightCharacteristics stats { get; set; }
		public IEnumerable<ushort> previousPositions { get; set; }

		public GameFightFighterInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.spawnInfo = spawnInfo;
			this.wave = wave;
			this.stats = stats;
			this.previousPositions = previousPositions;
		}

		public GameFightFighterInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			spawnInfo.Serialize(writer);
			writer.WriteSByte(wave);
			writer.WriteShort(stats.TypeId);
			stats.Serialize(writer);
			writer.WriteShort((short)previousPositions.Count());
			foreach (var objectToSend in previousPositions)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			spawnInfo = new GameContextBasicSpawnInformation();
			spawnInfo.Deserialize(reader);
			wave = reader.ReadSByte();
			stats = ProtocolTypeManager.GetInstance<GameFightCharacteristics>(reader.ReadShort());
			stats.Deserialize(reader);
			var previousPositionsCount = reader.ReadUShort();
			var previousPositions_ = new ushort[previousPositionsCount];
			for (var previousPositionsIndex = 0; previousPositionsIndex < previousPositionsCount; previousPositionsIndex++)
			{
				previousPositions_[previousPositionsIndex] = reader.ReadVarUShort();
			}
			previousPositions = previousPositions_;
		}

	}
}
