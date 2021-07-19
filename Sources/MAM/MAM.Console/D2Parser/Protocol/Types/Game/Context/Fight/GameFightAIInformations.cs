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
	public class GameFightAIInformations : GameFightFighterInformations
	{
		public new const short Id = 3226;
		public override short TypeId => Id;

		public GameFightAIInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, GameContextBasicSpawnInformation spawnInfo, sbyte wave, GameFightCharacteristics stats, IEnumerable<ushort> previousPositions)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.spawnInfo = spawnInfo;
			this.wave = wave;
			this.stats = stats;
			this.previousPositions = previousPositions;
		}

		public GameFightAIInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
