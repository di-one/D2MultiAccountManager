namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectItemInRolePlay
	{
		public const short Id  = 6471;
		public virtual short TypeId => Id;
		public ushort cellId { get; set; }
		public ushort objectGID { get; set; }

		public ObjectItemInRolePlay(ushort cellId, ushort objectGID)
		{
			this.cellId = cellId;
			this.objectGID = objectGID;
		}

		public ObjectItemInRolePlay() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(cellId);
			writer.WriteVarUShort(objectGID);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			cellId = reader.ReadVarUShort();
			objectGID = reader.ReadVarUShort();
		}

	}
}
