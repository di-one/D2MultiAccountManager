namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayPortalInformations : GameRolePlayActorInformations
	{
		public new const short Id = 4028;
		public override short TypeId => Id;
		public PortalInformation portal { get; set; }

		public GameRolePlayPortalInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, PortalInformation portal)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.portal = portal;
		}

		public GameRolePlayPortalInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(portal.TypeId);
			portal.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			portal = ProtocolTypeManager.GetInstance<PortalInformation>(reader.ReadShort());
			portal.Deserialize(reader);
		}

	}
}
