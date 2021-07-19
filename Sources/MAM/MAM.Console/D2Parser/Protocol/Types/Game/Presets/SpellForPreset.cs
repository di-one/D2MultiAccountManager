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
	public class SpellForPreset
	{
		public const short Id  = 6389;
		public virtual short TypeId => Id;
		public ushort spellId { get; set; }
		public IEnumerable<short> shortcuts { get; set; }

		public SpellForPreset(ushort spellId, IEnumerable<short> shortcuts)
		{
			this.spellId = spellId;
			this.shortcuts = shortcuts;
		}

		public SpellForPreset() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(spellId);
			writer.WriteShort((short)shortcuts.Count());
			foreach (var objectToSend in shortcuts)
            {
				writer.WriteShort(objectToSend);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			spellId = reader.ReadVarUShort();
			var shortcutsCount = reader.ReadUShort();
			var shortcuts_ = new short[shortcutsCount];
			for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
			{
				shortcuts_[shortcutsIndex] = reader.ReadShort();
			}
			shortcuts = shortcuts_;
		}

	}
}
