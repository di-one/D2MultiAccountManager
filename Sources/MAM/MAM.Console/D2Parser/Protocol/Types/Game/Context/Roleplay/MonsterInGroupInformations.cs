namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MonsterInGroupInformations : MonsterInGroupLightInformations
	{
		public new const short Id = 3872;
		public override short TypeId => Id;
		public EntityLook look { get; set; }

		public MonsterInGroupInformations(int genericId, sbyte grade, short level, EntityLook look)
		{
			this.genericId = genericId;
			this.grade = grade;
			this.level = level;
			this.look = look;
		}

		public MonsterInGroupInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			look.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			look = new EntityLook();
			look.Deserialize(reader);
		}

	}
}
