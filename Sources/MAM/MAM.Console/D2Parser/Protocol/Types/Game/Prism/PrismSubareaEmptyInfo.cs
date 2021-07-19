namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismSubareaEmptyInfo
	{
		public const short Id  = 4789;
		public virtual short TypeId => Id;
		public ushort subAreaId { get; set; }
		public uint allianceId { get; set; }

		public PrismSubareaEmptyInfo(ushort subAreaId, uint allianceId)
		{
			this.subAreaId = subAreaId;
			this.allianceId = allianceId;
		}

		public PrismSubareaEmptyInfo() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteVarUInt(allianceId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			allianceId = reader.ReadVarUInt();
		}

	}
}
