namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ShortcutObjectItem : ShortcutObject
	{
		public new const short Id = 3792;
		public override short TypeId => Id;
		public int itemUID { get; set; }
		public int itemGID { get; set; }

		public ShortcutObjectItem(sbyte slot, int itemUID, int itemGID)
		{
			this.slot = slot;
			this.itemUID = itemUID;
			this.itemGID = itemGID;
		}

		public ShortcutObjectItem() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(itemUID);
			writer.WriteInt(itemGID);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			itemUID = reader.ReadInt();
			itemGID = reader.ReadInt();
		}

	}
}
