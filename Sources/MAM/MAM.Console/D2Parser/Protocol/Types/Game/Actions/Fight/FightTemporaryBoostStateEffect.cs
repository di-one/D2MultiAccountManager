namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTemporaryBoostStateEffect : FightTemporaryBoostEffect
	{
		public new const short Id = 3474;
		public override short TypeId => Id;
		public short stateId { get; set; }

		public FightTemporaryBoostStateEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, ushort spellId, uint effectId, uint parentBoostUid, int delta, short stateId)
		{
			this.uid = uid;
			this.targetId = targetId;
			this.turnDuration = turnDuration;
			this.dispelable = dispelable;
			this.spellId = spellId;
			this.effectId = effectId;
			this.parentBoostUid = parentBoostUid;
			this.delta = delta;
			this.stateId = stateId;
		}

		public FightTemporaryBoostStateEffect() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(stateId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			stateId = reader.ReadShort();
		}

	}
}
