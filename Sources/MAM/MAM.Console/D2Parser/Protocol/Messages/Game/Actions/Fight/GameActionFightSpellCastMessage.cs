namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
	{
		public new const uint Id = 9132;
		public override uint MessageId => Id;
		public ushort spellId { get; set; }
		public short spellLevel { get; set; }
		public IEnumerable<short> portalsIds { get; set; }

		public GameActionFightSpellCastMessage(ushort actionId, double sourceId, bool silentCast, bool verboseCast, double targetId, short destinationCellId, sbyte critical, ushort spellId, short spellLevel, IEnumerable<short> portalsIds)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.silentCast = silentCast;
			this.verboseCast = verboseCast;
			this.targetId = targetId;
			this.destinationCellId = destinationCellId;
			this.critical = critical;
			this.spellId = spellId;
			this.spellLevel = spellLevel;
			this.portalsIds = portalsIds;
		}

		public GameActionFightSpellCastMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(spellId);
			writer.WriteShort(spellLevel);
			writer.WriteShort((short)portalsIds.Count());
			foreach (var objectToSend in portalsIds)
            {
				writer.WriteShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			spellId = reader.ReadVarUShort();
			spellLevel = reader.ReadShort();
			var portalsIdsCount = reader.ReadUShort();
			var portalsIds_ = new short[portalsIdsCount];
			for (var portalsIdsIndex = 0; portalsIdsIndex < portalsIdsCount; portalsIdsIndex++)
			{
				portalsIds_[portalsIdsIndex] = reader.ReadShort();
			}
			portalsIds = portalsIds_;
		}

	}
}
