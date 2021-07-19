namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class Idol
	{
		public const short Id  = 5210;
		public virtual short TypeId => Id;
		public ushort objectId { get; set; }
		public ushort xpBonusPercent { get; set; }
		public ushort dropBonusPercent { get; set; }

		public Idol(ushort objectId, ushort xpBonusPercent, ushort dropBonusPercent)
		{
			this.objectId = objectId;
			this.xpBonusPercent = xpBonusPercent;
			this.dropBonusPercent = dropBonusPercent;
		}

		public Idol() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(objectId);
			writer.WriteVarUShort(xpBonusPercent);
			writer.WriteVarUShort(dropBonusPercent);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUShort();
			xpBonusPercent = reader.ReadVarUShort();
			dropBonusPercent = reader.ReadVarUShort();
		}

	}
}
