namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
	{
		public new const short Id = 4623;
		public override short TypeId => Id;
		public string name { get; set; }

		public GameRolePlayNamedActorInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, string name)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.name = name;
		}

		public GameRolePlayNamedActorInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(name);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			name = reader.ReadUTF();
		}

	}
}
