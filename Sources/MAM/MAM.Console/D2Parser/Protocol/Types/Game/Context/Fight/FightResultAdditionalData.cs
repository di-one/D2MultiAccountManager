namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightResultAdditionalData
	{
		public const short Id  = 2515;
		public virtual short TypeId => Id;

		public FightResultAdditionalData() { }

		public virtual void Serialize(IDataWriter writer)
		{
		}

		public virtual void Deserialize(IDataReader reader)
		{
		}

	}
}
