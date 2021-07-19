namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
	{
		public new const short Id = 320;
		public override short TypeId => Id;
		public int delta { get; set; }

		public FightTemporaryBoostEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, ushort spellId, uint effectId, uint parentBoostUid, int delta)
		{
			this.uid = uid;
			this.targetId = targetId;
			this.turnDuration = turnDuration;
			this.dispelable = dispelable;
			this.spellId = spellId;
			this.effectId = effectId;
			this.parentBoostUid = parentBoostUid;
			this.delta = delta;
		}

		public FightTemporaryBoostEffect() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(delta);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			delta = reader.ReadInt();
		}

	}
}
