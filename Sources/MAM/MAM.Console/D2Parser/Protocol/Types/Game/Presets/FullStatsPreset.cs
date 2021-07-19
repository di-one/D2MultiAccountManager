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
	public class FullStatsPreset : Preset
	{
		public new const short Id = 3276;
		public override short TypeId => Id;
		public IEnumerable<CharacterCharacteristicForPreset> stats { get; set; }

		public FullStatsPreset(short objectId, IEnumerable<CharacterCharacteristicForPreset> stats)
		{
			this.objectId = objectId;
			this.stats = stats;
		}

		public FullStatsPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)stats.Count());
			foreach (var objectToSend in stats)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var statsCount = reader.ReadUShort();
			var stats_ = new CharacterCharacteristicForPreset[statsCount];
			for (var statsIndex = 0; statsIndex < statsCount; statsIndex++)
			{
				var objectToAdd = new CharacterCharacteristicForPreset();
				objectToAdd.Deserialize(reader);
				stats_[statsIndex] = objectToAdd;
			}
			stats = stats_;
		}

	}
}
