namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpellItem : Item
	{
		public new const short Id = 5350;
		public override short TypeId => Id;
		public int spellId { get; set; }
		public short spellLevel { get; set; }

		public SpellItem(int spellId, short spellLevel)
		{
			this.spellId = spellId;
			this.spellLevel = spellLevel;
		}

		public SpellItem() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(spellId);
			writer.WriteShort(spellLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			spellId = reader.ReadInt();
			spellLevel = reader.ReadShort();
		}

	}
}
