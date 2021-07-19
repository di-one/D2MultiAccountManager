namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect
	{
		public new const short Id = 2214;
		public override short TypeId => Id;
		public int immuneSpellId { get; set; }

		public FightTemporarySpellImmunityEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, ushort spellId, uint effectId, uint parentBoostUid, int immuneSpellId)
		{
			this.uid = uid;
			this.targetId = targetId;
			this.turnDuration = turnDuration;
			this.dispelable = dispelable;
			this.spellId = spellId;
			this.effectId = effectId;
			this.parentBoostUid = parentBoostUid;
			this.immuneSpellId = immuneSpellId;
		}

		public FightTemporarySpellImmunityEffect() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(immuneSpellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			immuneSpellId = reader.ReadInt();
		}

	}
}
