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
	public class GameFightTaxCollectorInformations : GameFightAIInformations
	{
		public new const short Id = 8023;
		public override short TypeId => Id;
		public ushort firstNameId { get; set; }
		public ushort lastNameId { get; set; }
		public byte level { get; set; }

		public GameFightTaxCollectorInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions, ushort firstNameId, ushort lastNameId, byte level)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.spawnInfo = spawnInfo;
			this.wave = wave;
			this.stats = stats;
			this.previousPositions = previousPositions;
			this.firstNameId = firstNameId;
			this.lastNameId = lastNameId;
			this.level = level;
		}

		public GameFightTaxCollectorInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(firstNameId);
			writer.WriteVarUShort(lastNameId);
			writer.WriteByte(level);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			firstNameId = reader.ReadVarUShort();
			lastNameId = reader.ReadVarUShort();
			level = reader.ReadByte();
		}

	}
}
