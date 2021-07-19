namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IndexedEntityLook
	{
		public const short Id  = 8160;
		public virtual short TypeId => Id;
		public EntityLook look { get; set; }
		public sbyte index { get; set; }

		public IndexedEntityLook(EntityLook look, sbyte index)
		{
			this.look = look;
			this.index = index;
		}

		public IndexedEntityLook() { }

		public virtual void Serialize(IDataWriter writer)
		{
			look.Serialize(writer);
			writer.WriteSByte(index);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			look = new EntityLook();
			look.Deserialize(reader);
			index = reader.ReadSByte();
		}

	}
}
