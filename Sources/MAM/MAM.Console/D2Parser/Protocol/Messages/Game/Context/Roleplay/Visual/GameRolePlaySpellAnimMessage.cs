namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlaySpellAnimMessage : NetworkMessage
	{
		public const uint Id = 3460;
		public override uint MessageId => Id;
		public ulong casterId { get; set; }
		public ushort targetCellId { get; set; }
		public ushort spellId { get; set; }
		public short spellLevel { get; set; }

		public GameRolePlaySpellAnimMessage(ulong casterId, ushort targetCellId, ushort spellId, short spellLevel)
		{
			this.casterId = casterId;
			this.targetCellId = targetCellId;
			this.spellId = spellId;
			this.spellLevel = spellLevel;
		}

		public GameRolePlaySpellAnimMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(casterId);
			writer.WriteVarUShort(targetCellId);
			writer.WriteVarUShort(spellId);
			writer.WriteShort(spellLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			casterId = reader.ReadVarULong();
			targetCellId = reader.ReadVarUShort();
			spellId = reader.ReadVarUShort();
			spellLevel = reader.ReadShort();
		}

	}
}
