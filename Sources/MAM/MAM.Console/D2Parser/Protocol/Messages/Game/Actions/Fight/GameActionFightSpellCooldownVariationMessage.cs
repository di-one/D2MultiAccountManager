namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightSpellCooldownVariationMessage : AbstractGameActionMessage
	{
		public new const uint Id = 3800;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public ushort spellId { get; set; }
		public short value { get; set; }

		public GameActionFightSpellCooldownVariationMessage(ushort actionId, double sourceId, double targetId, ushort spellId, short value)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.spellId = spellId;
			this.value = value;
		}

		public GameActionFightSpellCooldownVariationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteVarUShort(spellId);
			writer.WriteVarShort(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			spellId = reader.ReadVarUShort();
			value = reader.ReadVarShort();
		}

	}
}
