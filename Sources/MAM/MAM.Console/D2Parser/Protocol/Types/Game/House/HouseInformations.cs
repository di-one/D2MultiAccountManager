namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseInformations
	{
		public const short Id  = 3662;
		public virtual short TypeId => Id;
		public uint houseId { get; set; }
		public ushort modelId { get; set; }

		public HouseInformations(uint houseId, ushort modelId)
		{
			this.houseId = houseId;
			this.modelId = modelId;
		}

		public HouseInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(houseId);
			writer.WriteVarUShort(modelId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			houseId = reader.ReadVarUInt();
			modelId = reader.ReadVarUShort();
		}

	}
}
