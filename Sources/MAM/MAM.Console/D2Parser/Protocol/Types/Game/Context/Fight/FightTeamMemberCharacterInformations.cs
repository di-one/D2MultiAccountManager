namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTeamMemberCharacterInformations : FightTeamMemberInformations
	{
		public new const short Id = 3311;
		public override short TypeId => Id;
		public string name { get; set; }
		public ushort level { get; set; }

		public FightTeamMemberCharacterInformations(double objectId, string name, ushort level)
		{
			this.objectId = objectId;
			this.name = name;
			this.level = level;
		}

		public FightTeamMemberCharacterInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
			writer.WriteVarUShort(level);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
			level = reader.ReadVarUShort();
		}

	}
}
