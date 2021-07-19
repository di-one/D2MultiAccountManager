namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextActorInformations : GameContextActorPositionInformations
	{
		public new const short Id = 3338;
		public override short TypeId => Id;
		public EntityLook look { get; set; }

		public GameContextActorInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
		}

		public GameContextActorInformations() { }

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
