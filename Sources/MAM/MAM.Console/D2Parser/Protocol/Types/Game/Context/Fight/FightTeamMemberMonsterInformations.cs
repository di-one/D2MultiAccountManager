namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
	{
		public new const short Id = 8655;
		public override short TypeId => Id;
		public int monsterId { get; set; }
		public sbyte grade { get; set; }

		public FightTeamMemberMonsterInformations(double objectId, int monsterId, sbyte grade)
		{
			this.objectId = objectId;
			this.monsterId = monsterId;
			this.grade = grade;
		}

		public FightTeamMemberMonsterInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(monsterId);
			writer.WriteSByte(grade);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			monsterId = reader.ReadInt();
			grade = reader.ReadSByte();
		}

	}
}
