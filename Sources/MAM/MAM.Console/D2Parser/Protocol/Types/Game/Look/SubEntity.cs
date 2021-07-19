namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SubEntity
	{
		public const short Id  = 3806;
		public virtual short TypeId => Id;
		public sbyte bindingPointCategory { get; set; }
		public sbyte bindingPointIndex { get; set; }
		public EntityLook subEntityLook { get; set; }

		public SubEntity(sbyte bindingPointCategory, sbyte bindingPointIndex, EntityLook subEntityLook)
		{
			this.bindingPointCategory = bindingPointCategory;
			this.bindingPointIndex = bindingPointIndex;
			this.subEntityLook = subEntityLook;
		}

		public SubEntity() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(bindingPointCategory);
			writer.WriteSByte(bindingPointIndex);
			subEntityLook.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			bindingPointCategory = reader.ReadSByte();
			bindingPointIndex = reader.ReadSByte();
			subEntityLook = new EntityLook();
			subEntityLook.Deserialize(reader);
		}

	}
}
