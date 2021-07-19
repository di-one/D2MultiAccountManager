namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpellListMessage : NetworkMessage
	{
		public const uint Id = 8397;
		public override uint MessageId => Id;
		public bool spellPrevisualization { get; set; }
		public IEnumerable<SpellItem> spells { get; set; }

		public SpellListMessage(bool spellPrevisualization, IEnumerable<SpellItem> spells)
		{
			this.spellPrevisualization = spellPrevisualization;
			this.spells = spells;
		}

		public SpellListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(spellPrevisualization);
			writer.WriteShort((short)spells.Count());
			foreach (var objectToSend in spells)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			spellPrevisualization = reader.ReadBoolean();
			var spellsCount = reader.ReadUShort();
			var spells_ = new SpellItem[spellsCount];
			for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
			{
				var objectToAdd = new SpellItem();
				objectToAdd.Deserialize(reader);
				spells_[spellsIndex] = objectToAdd;
			}
			spells = spells_;
		}

	}
}
