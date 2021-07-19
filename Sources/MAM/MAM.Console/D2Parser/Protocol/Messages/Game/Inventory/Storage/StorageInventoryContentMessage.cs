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
	public class StorageInventoryContentMessage : InventoryContentMessage
	{
		public new const uint Id = 567;
		public override uint MessageId => Id;

		public StorageInventoryContentMessage(IEnumerable<ObjectItem> objects, ulong kamas)
		{
			this.objects = objects;
			this.kamas = kamas;
		}

		public StorageInventoryContentMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
