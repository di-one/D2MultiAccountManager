namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightShowFighterRandomStaticPoseMessage : GameFightShowFighterMessage
	{
		public new const uint Id = 2881;
		public override uint MessageId => Id;

		public GameFightShowFighterRandomStaticPoseMessage(GameFightFighterInformations informations)
		{
			this.informations = informations;
		}

		public GameFightShowFighterRandomStaticPoseMessage() { }

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
