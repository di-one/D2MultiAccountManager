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
	public class WatchInventoryContentMessage : InventoryContentMessage
	{
		public new const uint Id = 3036;
		public override uint MessageId => Id;

		public WatchInventoryContentMessage(IEnumerable<ObjectItem> objects, ulong kamas)
		{
			this.objects = objects;
			this.kamas = kamas;
		}

		public WatchInventoryContentMessage() { }

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
