namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AbstractFightDispellableEffect
	{
		public const short Id  = 1188;
		public virtual short TypeId => Id;
		public uint uid { get; set; }
		public double targetId { get; set; }
		public short turnDuration { get; set; }
		public sbyte dispelable { get; set; }
		public ushort spellId { get; set; }
		public uint effectId { get; set; }
		public uint parentBoostUid { get; set; }

		public AbstractFightDispellableEffect(uint uid, double targetId, short turnDuration, sbyte dispelable, ushort spellId, uint effectId, uint parentBoostUid)
		{
			this.uid = uid;
			this.targetId = targetId;
			this.turnDuration = turnDuration;
			this.dispelable = dispelable;
			this.spellId = spellId;
			this.effectId = effectId;
			this.parentBoostUid = parentBoostUid;
		}

		public AbstractFightDispellableEffect() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(uid);
			writer.WriteDouble(targetId);
			writer.WriteShort(turnDuration);
			writer.WriteSByte(dispelable);
			writer.WriteVarUShort(spellId);
			writer.WriteVarUInt(effectId);
			writer.WriteVarUInt(parentBoostUid);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			uid = reader.ReadVarUInt();
			targetId = reader.ReadDouble();
			turnDuration = reader.ReadShort();
			dispelable = reader.ReadSByte();
			spellId = reader.ReadVarUShort();
			effectId = reader.ReadVarUInt();
			parentBoostUid = reader.ReadVarUInt();
		}

	}
}
