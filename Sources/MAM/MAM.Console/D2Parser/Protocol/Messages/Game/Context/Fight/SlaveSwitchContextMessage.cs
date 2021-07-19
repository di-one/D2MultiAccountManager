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
	public class SlaveSwitchContextMessage : NetworkMessage
	{
		public const uint Id = 4446;
		public override uint MessageId => Id;
		public double masterId { get; set; }
		public double slaveId { get; set; }
		public ushort slaveTurn { get; set; }
		public IEnumerable<SpellItem> slaveSpells { get; set; }
		public CharacterCharacteristicsInformations slaveStats { get; set; }
		public IEnumerable<Shortcut> shortcuts { get; set; }

		public SlaveSwitchContextMessage(double masterId, double slaveId, ushort slaveTurn, IEnumerable<SpellItem> slaveSpells, CharacterCharacteristicsInformations slaveStats, IEnumerable<Shortcut> shortcuts)
		{
			this.masterId = masterId;
			this.slaveId = slaveId;
			this.slaveTurn = slaveTurn;
			this.slaveSpells = slaveSpells;
			this.slaveStats = slaveStats;
			this.shortcuts = shortcuts;
		}

		public SlaveSwitchContextMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(masterId);
			writer.WriteDouble(slaveId);
			writer.WriteVarUShort(slaveTurn);
			writer.WriteShort((short)slaveSpells.Count());
			foreach (var objectToSend in slaveSpells)
            {
				objectToSend.Serialize(writer);
			}
			slaveStats.Serialize(writer);
			writer.WriteShort((short)shortcuts.Count());
			foreach (var objectToSend in shortcuts)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			masterId = reader.ReadDouble();
			slaveId = reader.ReadDouble();
			slaveTurn = reader.ReadVarUShort();
			var slaveSpellsCount = reader.ReadUShort();
			var slaveSpells_ = new SpellItem[slaveSpellsCount];
			for (var slaveSpellsIndex = 0; slaveSpellsIndex < slaveSpellsCount; slaveSpellsIndex++)
			{
				var objectToAdd = new SpellItem();
				objectToAdd.Deserialize(reader);
				slaveSpells_[slaveSpellsIndex] = objectToAdd;
			}
			slaveSpells = slaveSpells_;
			slaveStats = new CharacterCharacteristicsInformations();
			slaveStats.Deserialize(reader);
			var shortcutsCount = reader.ReadUShort();
			var shortcuts_ = new Shortcut[shortcutsCount];
			for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				shortcuts_[shortcutsIndex] = objectToAdd;
			}
			shortcuts = shortcuts_;
		}

	}
}
