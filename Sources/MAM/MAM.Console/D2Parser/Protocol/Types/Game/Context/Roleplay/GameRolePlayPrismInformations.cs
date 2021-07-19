namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayPrismInformations : GameRolePlayActorInformations
	{
		public new const short Id = 7793;
		public override short TypeId => Id;
		public PrismInformation prism { get; set; }

		public GameRolePlayPrismInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look, PrismInformation prism)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
			this.prism = prism;
		}

		public GameRolePlayPrismInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(prism.TypeId);
			prism.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			prism = ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadShort());
			prism.Deserialize(reader);
		}

	}
}
