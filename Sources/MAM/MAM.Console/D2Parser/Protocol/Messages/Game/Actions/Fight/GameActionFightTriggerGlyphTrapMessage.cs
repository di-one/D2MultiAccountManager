namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
	{
		public new const uint Id = 9566;
		public override uint MessageId => Id;
		public short markId { get; set; }
		public ushort markImpactCell { get; set; }
		public double triggeringCharacterId { get; set; }
		public ushort triggeredSpellId { get; set; }

		public GameActionFightTriggerGlyphTrapMessage(ushort actionId, double sourceId, short markId, ushort markImpactCell, double triggeringCharacterId, ushort triggeredSpellId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.markId = markId;
			this.markImpactCell = markImpactCell;
			this.triggeringCharacterId = triggeringCharacterId;
			this.triggeredSpellId = triggeredSpellId;
		}

		public GameActionFightTriggerGlyphTrapMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(markId);
			writer.WriteVarUShort(markImpactCell);
			writer.WriteDouble(triggeringCharacterId);
			writer.WriteVarUShort(triggeredSpellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			markId = reader.ReadShort();
			markImpactCell = reader.ReadVarUShort();
			triggeringCharacterId = reader.ReadDouble();
			triggeredSpellId = reader.ReadVarUShort();
		}

	}
}
