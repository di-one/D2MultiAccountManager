namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutSpell : Shortcut
	{
		public new const short Id = 8389;
		public override short TypeId => Id;
		public ushort spellId { get; set; }

		public ShortcutSpell(sbyte slot, ushort spellId)
		{
			this.slot = slot;
			this.spellId = spellId;
		}

		public ShortcutSpell() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(spellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			spellId = reader.ReadVarUShort();
		}

	}
}
