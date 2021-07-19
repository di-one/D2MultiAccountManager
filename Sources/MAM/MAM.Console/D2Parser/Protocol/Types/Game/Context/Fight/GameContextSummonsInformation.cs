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
	public class GameContextSummonsInformation
	{
		public const short Id  = 9597;
		public virtual short TypeId => Id;
		public SpawnInformation spawnInformation { get; set; }
		public sbyte wave { get; set; }
		public EntityLook look { get; set; }
		public GameFightCharacteristics stats { get; set; }
		public IEnumerable<GameContextBasicSpawnInformation> summons { get; set; }

		public GameContextSummonsInformation(SpawnInformation spawnInformation, sbyte wave, EntityLook look, GameFightCharacteristics stats, IEnumerable<GameContextBasicSpawnInformation> summons)
		{
			this.spawnInformation = spawnInformation;
			this.wave = wave;
			this.look = look;
			this.stats = stats;
			this.summons = summons;
		}

		public GameContextSummonsInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort(spawnInformation.TypeId);
			spawnInformation.Serialize(writer);
			writer.WriteSByte(wave);
			look.Serialize(writer);
			writer.WriteShort(stats.TypeId);
			stats.Serialize(writer);
			writer.WriteShort((short)summons.Count());
			foreach (var objectToSend in summons)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			spawnInformation = ProtocolTypeManager.GetInstance<SpawnInformation>(reader.ReadShort());
			spawnInformation.Deserialize(reader);
			wave = reader.ReadSByte();
			look = new EntityLook();
			look.Deserialize(reader);
			stats = ProtocolTypeManager.GetInstance<GameFightCharacteristics>(reader.ReadShort());
			stats.Deserialize(reader);
			var summonsCount = reader.ReadUShort();
			var summons_ = new GameContextBasicSpawnInformation[summonsCount];
			for (var summonsIndex = 0; summonsIndex < summonsCount; summonsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<GameContextBasicSpawnInformation>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				summons_[summonsIndex] = objectToAdd;
			}
			summons = summons_;
		}

	}
}
