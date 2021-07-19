namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MonsterBoosts
	{
		public const short Id  = 5803;
		public virtual short TypeId => Id;
		public uint objectId { get; set; }
		public ushort xpBoost { get; set; }
		public ushort dropBoost { get; set; }

		public MonsterBoosts(uint objectId, ushort xpBoost, ushort dropBoost)
		{
			this.objectId = objectId;
			this.xpBoost = xpBoost;
			this.dropBoost = dropBoost;
		}

		public MonsterBoosts() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectId);
			writer.WriteVarUShort(xpBoost);
			writer.WriteVarUShort(dropBoost);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUInt();
			xpBoost = reader.ReadVarUShort();
			dropBoost = reader.ReadVarUShort();
		}

	}
}
