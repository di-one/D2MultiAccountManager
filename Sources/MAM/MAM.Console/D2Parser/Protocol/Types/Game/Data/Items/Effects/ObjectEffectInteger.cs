namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffectInteger : ObjectEffect
	{
		public new const short Id = 624;
		public override short TypeId => Id;
		public uint value { get; set; }

		public ObjectEffectInteger(ushort actionId, uint value)
		{
			this.actionId = actionId;
			this.value = value;
		}

		public ObjectEffectInteger() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadVarUInt();
		}

	}
}
