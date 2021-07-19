namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightDispellSpellMessage : GameActionFightDispellMessage
	{
		public new const uint Id = 3642;
		public override uint MessageId => Id;
		public ushort spellId { get; set; }

		public GameActionFightDispellSpellMessage(ushort actionId, double sourceId, double targetId, bool verboseCast, ushort spellId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.verboseCast = verboseCast;
			this.spellId = spellId;
		}

		public GameActionFightDispellSpellMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(spellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			spellId = reader.ReadVarUShort();
		}

	}
}
