namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect
	{
		public new const short Id = 7744;
		public override short TypeId => Id;
		public short weaponTypeId { get; set; }

		public FightTemporaryBoostWeaponDamagesEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, ushort spellId, uint effectId, uint parentBoostUid, int delta, short weaponTypeId)
		{
			this.uid = uid;
			this.targetId = targetId;
			this.turnDuration = turnDuration;
			this.dispelable = dispelable;
			this.spellId = spellId;
			this.effectId = effectId;
			this.parentBoostUid = parentBoostUid;
			this.delta = delta;
			this.weaponTypeId = weaponTypeId;
		}

		public FightTemporaryBoostWeaponDamagesEffect() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(weaponTypeId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			weaponTypeId = reader.ReadShort();
		}

	}
}
