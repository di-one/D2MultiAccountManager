namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
	{
		public new const short Id = 8477;
		public override short TypeId => Id;
		public ushort boostedSpellId { get; set; }

		public FightTemporarySpellBoostEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, ushort spellId, uint effectId, uint parentBoostUid, int delta, ushort boostedSpellId)
		{
			this.uid = uid;
			this.targetId = targetId;
			this.turnDuration = turnDuration;
			this.dispelable = dispelable;
			this.spellId = spellId;
			this.effectId = effectId;
			this.parentBoostUid = parentBoostUid;
			this.delta = delta;
			this.boostedSpellId = boostedSpellId;
		}

		public FightTemporarySpellBoostEffect() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(boostedSpellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			boostedSpellId = reader.ReadVarUShort();
		}

	}
}
