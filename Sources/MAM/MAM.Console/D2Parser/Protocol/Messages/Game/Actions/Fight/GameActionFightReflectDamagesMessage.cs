namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightReflectDamagesMessage : AbstractGameActionMessage
	{
		public new const uint Id = 1499;
		public override uint MessageId => Id;
		public double targetId { get; set; }

		public GameActionFightReflectDamagesMessage(ushort actionId, double sourceId, double targetId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
		}

		public GameActionFightReflectDamagesMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
		}

	}
}
