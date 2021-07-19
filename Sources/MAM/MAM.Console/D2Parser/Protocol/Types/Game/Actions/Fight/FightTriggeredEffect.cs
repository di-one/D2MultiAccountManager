namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightTriggeredEffect : AbstractFightDispellableEffect
	{
		public new const short Id = 977;
		public override short TypeId => Id;
		public int param1 { get; set; }
		public int param2 { get; set; }
		public int param3 { get; set; }
		public short delay { get; set; }

		public FightTriggeredEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, ushort spellId, uint effectId, uint parentBoostUid, int param1, int param2, int param3, short delay)
		{
			this.uid = uid;
			this.targetId = targetId;
			this.turnDuration = turnDuration;
			this.dispelable = dispelable;
			this.spellId = spellId;
			this.effectId = effectId;
			this.parentBoostUid = parentBoostUid;
			this.param1 = param1;
			this.param2 = param2;
			this.param3 = param3;
			this.delay = delay;
		}

		public FightTriggeredEffect() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(param1);
			writer.WriteInt(param2);
			writer.WriteInt(param3);
			writer.WriteShort(delay);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			param1 = reader.ReadInt();
			param2 = reader.ReadInt();
			param3 = reader.ReadInt();
			delay = reader.ReadShort();
		}

	}
}
