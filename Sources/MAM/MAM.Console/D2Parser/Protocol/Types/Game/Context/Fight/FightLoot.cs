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
	public class FightLoot
	{
		public const short Id  = 1098;
		public virtual short TypeId => Id;
		public IEnumerable<uint> objects { get; set; }
		public ulong kamas { get; set; }

		public FightLoot(IEnumerable<uint> objects, ulong kamas)
		{
			this.objects = objects;
			this.kamas = kamas;
		}

		public FightLoot() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)objects.Count());
			foreach (var objectToSend in objects)
            {
				writer.WriteVarUInt(objectToSend);
			}
			writer.WriteVarULong(kamas);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var objectsCount = reader.ReadUShort();
			var objects_ = new uint[objectsCount];
			for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
			{
				objects_[objectsIndex] = reader.ReadVarUInt();
			}
			objects = objects_;
			kamas = reader.ReadVarULong();
		}

	}
}
