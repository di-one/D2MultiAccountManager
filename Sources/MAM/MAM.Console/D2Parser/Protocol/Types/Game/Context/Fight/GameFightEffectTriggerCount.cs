namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightEffectTriggerCount
	{
		public const short Id  = 2413;
		public virtual short TypeId => Id;
		public uint effectId { get; set; }
		public double targetId { get; set; }
		public sbyte count { get; set; }

		public GameFightEffectTriggerCount(uint effectId, double targetId, sbyte count)
		{
			this.effectId = effectId;
			this.targetId = targetId;
			this.count = count;
		}

		public GameFightEffectTriggerCount() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(effectId);
			writer.WriteDouble(targetId);
			writer.WriteSByte(count);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			effectId = reader.ReadVarUInt();
			targetId = reader.ReadDouble();
			count = reader.ReadSByte();
		}

	}
}
