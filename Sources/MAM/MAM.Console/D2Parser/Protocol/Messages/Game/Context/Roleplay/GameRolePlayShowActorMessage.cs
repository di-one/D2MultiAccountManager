namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayShowActorMessage : NetworkMessage
	{
		public const uint Id = 2285;
		public override uint MessageId => Id;
		public GameRolePlayActorInformations informations { get; set; }

		public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations)
		{
			this.informations = informations;
		}

		public GameRolePlayShowActorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(informations.TypeId);
			informations.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			informations = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
			informations.Deserialize(reader);
		}

	}
}
