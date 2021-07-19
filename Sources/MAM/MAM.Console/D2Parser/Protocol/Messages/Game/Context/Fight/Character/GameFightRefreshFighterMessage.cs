namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightRefreshFighterMessage : NetworkMessage
	{
		public const uint Id = 1835;
		public override uint MessageId => Id;
		public GameContextActorInformations informations { get; set; }

		public GameFightRefreshFighterMessage(GameContextActorInformations informations)
		{
			this.informations = informations;
		}

		public GameFightRefreshFighterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(informations.TypeId);
			informations.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			informations = ProtocolTypeManager.GetInstance<GameContextActorInformations>(reader.ReadShort());
			informations.Deserialize(reader);
		}

	}
}
