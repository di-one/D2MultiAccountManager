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
	public class ForgettableSpellsPreset : Preset
	{
		public new const short Id = 8969;
		public override short TypeId => Id;
		public SpellsPreset baseSpellsPreset { get; set; }
		public IEnumerable<SpellForPreset> forgettableSpells { get; set; }

		public ForgettableSpellsPreset(short objectId, SpellsPreset baseSpellsPreset, IEnumerable<SpellForPreset> forgettableSpells)
		{
			this.objectId = objectId;
			this.baseSpellsPreset = baseSpellsPreset;
			this.forgettableSpells = forgettableSpells;
		}

		public ForgettableSpellsPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			baseSpellsPreset.Serialize(writer);
			writer.WriteShort((short)forgettableSpells.Count());
			foreach (var objectToSend in forgettableSpells)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			baseSpellsPreset = new SpellsPreset();
			baseSpellsPreset.Deserialize(reader);
			var forgettableSpellsCount = reader.ReadUShort();
			var forgettableSpells_ = new SpellForPreset[forgettableSpellsCount];
			for (var forgettableSpellsIndex = 0; forgettableSpellsIndex < forgettableSpellsCount; forgettableSpellsIndex++)
			{
				var objectToAdd = new SpellForPreset();
				objectToAdd.Deserialize(reader);
				forgettableSpells_[forgettableSpellsIndex] = objectToAdd;
			}
			forgettableSpells = forgettableSpells_;
		}

	}
}
