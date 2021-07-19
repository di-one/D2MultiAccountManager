namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HumanOptionObjectUse : HumanOption
	{
		public new const short Id = 8293;
		public override short TypeId => Id;
		public sbyte delayTypeId { get; set; }
		public double delayEndTime { get; set; }
		public ushort objectGID { get; set; }

		public HumanOptionObjectUse(sbyte delayTypeId, double delayEndTime, ushort objectGID)
		{
			this.delayTypeId = delayTypeId;
			this.delayEndTime = delayEndTime;
			this.objectGID = objectGID;
		}

		public HumanOptionObjectUse() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(delayTypeId);
			writer.WriteDouble(delayEndTime);
			writer.WriteVarUShort(objectGID);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			delayTypeId = reader.ReadSByte();
			delayEndTime = reader.ReadDouble();
			objectGID = reader.ReadVarUShort();
		}

	}
}
