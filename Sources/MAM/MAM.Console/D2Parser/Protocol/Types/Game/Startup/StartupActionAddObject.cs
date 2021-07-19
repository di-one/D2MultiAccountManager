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
	public class StartupActionAddObject
	{
		public const short Id  = 7573;
		public virtual short TypeId => Id;
		public int uid { get; set; }
		public string title { get; set; }
		public string text { get; set; }
		public string descUrl { get; set; }
		public string pictureUrl { get; set; }
		public IEnumerable<ObjectItemInformationWithQuantity> items { get; set; }

		public StartupActionAddObject(int uid, string title, string text, string descUrl, string pictureUrl, IEnumerable<ObjectItemInformationWithQuantity> items)
		{
			this.uid = uid;
			this.title = title;
			this.text = text;
			this.descUrl = descUrl;
			this.pictureUrl = pictureUrl;
			this.items = items;
		}

		public StartupActionAddObject() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(uid);
			writer.WriteUTF(title);
			writer.WriteUTF(text);
			writer.WriteUTF(descUrl);
			writer.WriteUTF(pictureUrl);
			writer.WriteShort((short)items.Count());
			foreach (var objectToSend in items)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			uid = reader.ReadInt();
			title = reader.ReadUTF();
			text = reader.ReadUTF();
			descUrl = reader.ReadUTF();
			pictureUrl = reader.ReadUTF();
			var itemsCount = reader.ReadUShort();
			var items_ = new ObjectItemInformationWithQuantity[itemsCount];
			for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
			{
				var objectToAdd = new ObjectItemInformationWithQuantity();
				objectToAdd.Deserialize(reader);
				items_[itemsIndex] = objectToAdd;
			}
			items = items_;
		}

	}
}
