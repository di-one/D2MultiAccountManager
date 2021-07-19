namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayShowActorWithEventMessage : GameRolePlayShowActorMessage
	{
		public new const uint Id = 1688;
		public override uint MessageId => Id;
		public sbyte actorEventId { get; set; }

		public GameRolePlayShowActorWithEventMessage(GameRolePlayActorInformations informations, sbyte actorEventId)
		{
			this.informations = informations;
			this.actorEventId = actorEventId;
		}

		public GameRolePlayShowActorWithEventMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(actorEventId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			actorEventId = reader.ReadSByte();
		}

	}
}
