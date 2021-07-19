namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightSpellImmunityMessage : AbstractGameActionMessage
	{
		public new const uint Id = 23;
		public override uint MessageId => Id;
		public double targetId { get; set; }
		public ushort spellId { get; set; }

		public GameActionFightSpellImmunityMessage(ushort actionId, double sourceId, double targetId, ushort spellId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.spellId = spellId;
		}

		public GameActionFightSpellImmunityMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(targetId);
			writer.WriteVarUShort(spellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			targetId = reader.ReadDouble();
			spellId = reader.ReadVarUShort();
		}

	}
}
