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
	public class ForgettableSpellListUpdateMessage : NetworkMessage
	{
		public const uint Id = 2693;
		public override uint MessageId => Id;
		public sbyte action { get; set; }
		public IEnumerable<ForgettableSpellItem> spells { get; set; }

		public ForgettableSpellListUpdateMessage(sbyte action, IEnumerable<ForgettableSpellItem> spells)
		{
			this.action = action;
			this.spells = spells;
		}

		public ForgettableSpellListUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(action);
			writer.WriteShort((short)spells.Count());
			foreach (var objectToSend in spells)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			action = reader.ReadSByte();
			var spellsCount = reader.ReadUShort();
			var spells_ = new ForgettableSpellItem[spellsCount];
			for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
			{
				var objectToAdd = new ForgettableSpellItem();
				objectToAdd.Deserialize(reader);
				spells_[spellsIndex] = objectToAdd;
			}
			spells = spells_;
		}

	}
}
