namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyEntityBaseInformation
	{
		public const short Id  = 8446;
		public virtual short TypeId => Id;
		public sbyte indexId { get; set; }
		public sbyte entityModelId { get; set; }
		public EntityLook entityLook { get; set; }

		public PartyEntityBaseInformation(sbyte indexId, sbyte entityModelId, EntityLook entityLook)
		{
			this.indexId = indexId;
			this.entityModelId = entityModelId;
			this.entityLook = entityLook;
		}

		public PartyEntityBaseInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(indexId);
			writer.WriteSByte(entityModelId);
			entityLook.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			indexId = reader.ReadSByte();
			entityModelId = reader.ReadSByte();
			entityLook = new EntityLook();
			entityLook.Deserialize(reader);
		}

	}
}
