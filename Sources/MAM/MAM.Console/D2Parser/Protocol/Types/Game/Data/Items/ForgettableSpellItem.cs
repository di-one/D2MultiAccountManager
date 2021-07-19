namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ForgettableSpellItem : SpellItem
	{
		public new const short Id = 2709;
		public override short TypeId => Id;
		public bool available { get; set; }

		public ForgettableSpellItem(int spellId, short spellLevel, bool available)
		{
			this.spellId = spellId;
			this.spellLevel = spellLevel;
			this.available = available;
		}

		public ForgettableSpellItem() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(available);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			available = reader.ReadBoolean();
		}

	}
}
