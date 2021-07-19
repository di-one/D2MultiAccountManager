namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PortalInformation
	{
		public const short Id  = 2566;
		public virtual short TypeId => Id;
		public int portalId { get; set; }
		public short areaId { get; set; }

		public PortalInformation(int portalId, short areaId)
		{
			this.portalId = portalId;
			this.areaId = areaId;
		}

		public PortalInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(portalId);
			writer.WriteShort(areaId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			portalId = reader.ReadInt();
			areaId = reader.ReadShort();
		}

	}
}
