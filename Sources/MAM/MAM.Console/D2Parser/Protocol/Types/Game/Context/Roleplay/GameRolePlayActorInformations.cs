namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayActorInformations : GameContextActorInformations
	{
		public new const short Id = 5720;
		public override short TypeId => Id;

		public GameRolePlayActorInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
			this.look = look;
		}

		public GameRolePlayActorInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
