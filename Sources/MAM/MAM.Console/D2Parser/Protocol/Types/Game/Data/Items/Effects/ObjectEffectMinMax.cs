namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffectMinMax : ObjectEffect
	{
		public new const short Id = 6930;
		public override short TypeId => Id;
		public uint min { get; set; }
		public uint max { get; set; }

		public ObjectEffectMinMax(ushort actionId, uint min, uint max)
		{
			this.actionId = actionId;
			this.min = min;
			this.max = max;
		}

		public ObjectEffectMinMax() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(min);
			writer.WriteVarUInt(max);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			min = reader.ReadVarUInt();
			max = reader.ReadVarUInt();
		}

	}
}
