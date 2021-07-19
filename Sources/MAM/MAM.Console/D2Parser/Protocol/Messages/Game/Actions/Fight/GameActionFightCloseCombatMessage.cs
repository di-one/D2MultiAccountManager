namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
	{
		public new const uint Id = 1779;
		public override uint MessageId => Id;
		public ushort weaponGenericId { get; set; }

		public GameActionFightCloseCombatMessage(ushort actionId, double sourceId, bool silentCast, bool verboseCast, double targetId, short destinationCellId, sbyte critical, ushort weaponGenericId)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.silentCast = silentCast;
			this.verboseCast = verboseCast;
			this.targetId = targetId;
			this.destinationCellId = destinationCellId;
			this.critical = critical;
			this.weaponGenericId = weaponGenericId;
		}

		public GameActionFightCloseCombatMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(weaponGenericId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			weaponGenericId = reader.ReadVarUShort();
		}

	}
}
