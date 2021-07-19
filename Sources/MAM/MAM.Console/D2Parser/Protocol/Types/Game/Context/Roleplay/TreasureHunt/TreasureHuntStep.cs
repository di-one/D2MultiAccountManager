namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntStep
	{
		public const short Id  = 9693;
		public virtual short TypeId => Id;

		public TreasureHuntStep() { }

		public virtual void Serialize(IDataWriter writer)
		{
		}

		public virtual void Deserialize(IDataReader reader)
		{
		}

	}
}
