namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PaddockInformations
	{
		public const short Id  = 1010;
		public virtual short TypeId => Id;
		public ushort maxOutdoorMount { get; set; }
		public ushort maxItems { get; set; }

		public PaddockInformations(ushort maxOutdoorMount, ushort maxItems)
		{
			this.maxOutdoorMount = maxOutdoorMount;
			this.maxItems = maxItems;
		}

		public PaddockInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(maxOutdoorMount);
			writer.WriteVarUShort(maxItems);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			maxOutdoorMount = reader.ReadVarUShort();
			maxItems = reader.ReadVarUShort();
		}

	}
}
