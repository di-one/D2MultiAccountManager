namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MonsterInGroupLightInformations
	{
		public const short Id  = 3401;
		public virtual short TypeId => Id;
		public int genericId { get; set; }
		public sbyte grade { get; set; }
		public short level { get; set; }

		public MonsterInGroupLightInformations(int genericId, sbyte grade, short level)
		{
			this.genericId = genericId;
			this.grade = grade;
			this.level = level;
		}

		public MonsterInGroupLightInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(genericId);
			writer.WriteSByte(grade);
			writer.WriteShort(level);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			genericId = reader.ReadInt();
			grade = reader.ReadSByte();
			level = reader.ReadShort();
		}

	}
}
