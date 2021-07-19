namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class Item
	{
		public const short Id  = 4071;
		public virtual short TypeId => Id;

		public Item() { }

		public virtual void Serialize(IDataWriter writer)
		{
		}

		public virtual void Deserialize(IDataReader reader)
		{
		}

	}
}
