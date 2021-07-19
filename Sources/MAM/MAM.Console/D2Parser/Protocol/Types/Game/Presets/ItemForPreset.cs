namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ItemForPreset
	{
		public const short Id  = 5057;
		public virtual short TypeId => Id;
		public short position { get; set; }
		public ushort objGid { get; set; }
		public uint objUid { get; set; }

		public ItemForPreset(short position, ushort objGid, uint objUid)
		{
			this.position = position;
			this.objGid = objGid;
			this.objUid = objUid;
		}

		public ItemForPreset() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort(position);
			writer.WriteVarUShort(objGid);
			writer.WriteVarUInt(objUid);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			position = reader.ReadShort();
			objGid = reader.ReadVarUShort();
			objUid = reader.ReadVarUInt();
		}

	}
}
