namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightLifePointsGainMessage : AbstractGameActionMessage
	{
		public new const uint Id = 6278;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public uint delta { get; set; }

		public GameActionFightLifePointsGainMessage(ushort actionId, double sourceId, double targetId, uint delta)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.delta = delta;
		}

		public GameActionFightLifePointsGainMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteVarUInt(delta);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			delta = reader.ReadVarUInt();
		}

	}
}
