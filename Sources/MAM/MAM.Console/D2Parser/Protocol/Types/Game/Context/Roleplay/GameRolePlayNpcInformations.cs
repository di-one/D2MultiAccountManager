namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayNpcInformations : GameRolePlayActorInformations
	{
		public new const short Id = 5203;
		public override short TypeId => Id;
		public ushort npcId { get; set; }
		public bool sex { get; set; }
		public ushort specialArtworkId { get; set; }

		public GameRolePlayNpcInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, ushort npcId, bool sex, ushort specialArtworkId)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.npcId = npcId;
			this.sex = sex;
			this.specialArtworkId = specialArtworkId;
		}

		public GameRolePlayNpcInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(npcId);
			writer.WriteBoolean(sex);
			writer.WriteVarUShort(specialArtworkId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			npcId = reader.ReadVarUShort();
			sex = reader.ReadBoolean();
			specialArtworkId = reader.ReadVarUShort();
		}

	}
}
