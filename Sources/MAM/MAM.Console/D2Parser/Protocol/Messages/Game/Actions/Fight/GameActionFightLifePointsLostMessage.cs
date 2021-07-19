namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage
	{
		public new const uint Id = 5685;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public uint loss { get; set; }
		public uint permanentDamages { get; set; }
		public int elementId { get; set; }

		public GameActionFightLifePointsLostMessage(ushort actionId, double sourceId, double targetId, uint loss, uint permanentDamages, int elementId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.loss = loss;
			this.permanentDamages = permanentDamages;
			this.elementId = elementId;
		}

		public GameActionFightLifePointsLostMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteVarUInt(loss);
			writer.WriteVarUInt(permanentDamages);
			writer.WriteVarInt(elementId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			loss = reader.ReadVarUInt();
			permanentDamages = reader.ReadVarUInt();
			elementId = reader.ReadVarInt();
		}

	}
}
