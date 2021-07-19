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
	public class StatsPreset : Preset
	{
		public new const short Id = 4860;
		public override short TypeId => Id;
		public IEnumerable<SimpleCharacterCharacteristicForPreset> stats { get; set; }

		public StatsPreset(short objectId, IEnumerable<SimpleCharacterCharacteristicForPreset> stats)
		{
			this.objectId = objectId;
			this.stats = stats;
		}

		public StatsPreset() { }

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
			var stats_ = new SimpleCharacterCharacteristicForPreset[statsCount];
			for (var statsIndex = 0; statsIndex < statsCount; statsIndex++)
			{
				var objectToAdd = new SimpleCharacterCharacteristicForPreset();
				objectToAdd.Deserialize(reader);
				stats_[statsIndex] = objectToAdd;
			}
			stats = stats_;
		}

	}
}
