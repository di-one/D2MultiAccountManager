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
	public class SpellsPreset : Preset
	{
		public new const short Id = 3330;
		public override short TypeId => Id;
		public IEnumerable<SpellForPreset> spells { get; set; }

		public SpellsPreset(short objectId, IEnumerable<SpellForPreset> spells)
		{
			this.objectId = objectId;
			this.spells = spells;
		}

		public SpellsPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)spells.Count());
			foreach (var objectToSend in spells)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var spellsCount = reader.ReadUShort();
			var spells_ = new SpellForPreset[spellsCount];
			for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
			{
				var objectToAdd = new SpellForPreset();
				objectToAdd.Deserialize(reader);
				spells_[spellsIndex] = objectToAdd;
			}
			spells = spells_;
		}

	}
}
