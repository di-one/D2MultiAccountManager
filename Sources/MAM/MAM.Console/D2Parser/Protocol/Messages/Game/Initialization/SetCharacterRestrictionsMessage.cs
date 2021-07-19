namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SetCharacterRestrictionsMessage : NetworkMessage
	{
		public const uint Id = 4678;
		public override uint MessageId => Id;
		public double actorId { get; set; }
		public ActorRestrictionsInformations restrictions { get; set; }

		public SetCharacterRestrictionsMessage(double actorId, ActorRestrictionsInformations restrictions)
		{
			this.actorId = actorId;
			this.restrictions = restrictions;
		}

		public SetCharacterRestrictionsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(actorId);
			restrictions.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			actorId = reader.ReadDouble();
			restrictions = new ActorRestrictionsInformations();
			restrictions.Deserialize(reader);
		}

	}
}
