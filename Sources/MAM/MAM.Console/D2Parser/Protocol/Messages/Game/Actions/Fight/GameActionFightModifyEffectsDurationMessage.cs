namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightModifyEffectsDurationMessage : AbstractGameActionMessage
	{
		public new const uint Id = 4973;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public short delta { get; set; }

		public GameActionFightModifyEffectsDurationMessage(ushort actionId, double sourceId, double targetId, short delta)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.delta = delta;
		}

		public GameActionFightModifyEffectsDurationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteShort(delta);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			delta = reader.ReadShort();
		}

	}
}
