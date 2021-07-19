namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightShowFighterMessage : NetworkMessage
	{
		public const uint Id = 6252;
		public override uint MessageId => Id;
		public GameFightFighterInformations informations { get; set; }

		public GameFightShowFighterMessage(GameFightFighterInformations informations)
		{
			this.informations = informations;
		}

		public GameFightShowFighterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(informations.TypeId);
			informations.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			informations = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
			informations.Deserialize(reader);
		}

	}
}
