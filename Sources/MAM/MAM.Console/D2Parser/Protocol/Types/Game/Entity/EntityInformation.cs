namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EntityInformation
	{
		public const short Id  = 1159;
		public virtual short TypeId => Id;
		public ushort objectId { get; set; }
		public uint experience { get; set; }
		public bool status { get; set; }

		public EntityInformation(ushort objectId, uint experience, bool status)
		{
			this.objectId = objectId;
			this.experience = experience;
			this.status = status;
		}

		public EntityInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectId);
			writer.WriteVarUInt(experience);
			writer.WriteBoolean(status);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUShort();
			experience = reader.ReadVarUInt();
			status = reader.ReadBoolean();
		}

	}
}
