namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayTreasureHintInformations : GameRolePlayActorInformations
	{
		public new const short Id = 3649;
		public override short TypeId => Id;
		public ushort npcId { get; set; }

		public GameRolePlayTreasureHintInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, ushort npcId)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.npcId = npcId;
		}

		public GameRolePlayTreasureHintInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(npcId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			npcId = reader.ReadVarUShort();
		}

	}
}
