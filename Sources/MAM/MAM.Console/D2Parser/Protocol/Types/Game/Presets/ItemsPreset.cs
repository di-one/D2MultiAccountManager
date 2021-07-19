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
	public class ItemsPreset : Preset
	{
		public new const short Id = 5347;
		public override short TypeId => Id;
		public IEnumerable<ItemForPreset> items { get; set; }
		public bool mountEquipped { get; set; }
		public EntityLook look { get; set; }

		public ItemsPreset(short objectId, IEnumerable<ItemForPreset> items, bool mountEquipped, EntityLook look)
		{
			this.objectId = objectId;
			this.items = items;
			this.mountEquipped = mountEquipped;
			this.look = look;
		}

		public ItemsPreset() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)items.Count());
			foreach (var objectToSend in items)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteBoolean(mountEquipped);
			look.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var itemsCount = reader.ReadUShort();
			var items_ = new ItemForPreset[itemsCount];
			for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
			{
				var objectToAdd = new ItemForPreset();
				objectToAdd.Deserialize(reader);
				items_[itemsIndex] = objectToAdd;
			}
			items = items_;
			mountEquipped = reader.ReadBoolean();
			look = new EntityLook();
			look.Deserialize(reader);
		}

	}
}
