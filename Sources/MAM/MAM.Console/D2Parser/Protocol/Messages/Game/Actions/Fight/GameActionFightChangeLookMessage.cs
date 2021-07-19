namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightChangeLookMessage : AbstractGameActionMessage
	{
		public new const uint Id = 9994;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public EntityLook entityLook { get; set; }

		public GameActionFightChangeLookMessage(ushort actionId, double sourceId, double targetId, EntityLook entityLook)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.entityLook = entityLook;
		}

		public GameActionFightChangeLookMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			entityLook.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			entityLook = new EntityLook();
			entityLook.Deserialize(reader);
		}

	}
}
