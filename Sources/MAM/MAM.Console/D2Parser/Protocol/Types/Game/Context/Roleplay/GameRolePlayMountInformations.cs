namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
	{
		public new const short Id = 2326;
		public override short TypeId => Id;
		public string ownerName { get; set; }
		public byte level { get; set; }

		public GameRolePlayMountInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, string name, string ownerName, byte level)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.name = name;
			this.ownerName = ownerName;
			this.level = level;
		}

		public GameRolePlayMountInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(ownerName);
			writer.WriteByte(level);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			ownerName = reader.ReadUTF();
			level = reader.ReadByte();
		}

	}
}
