namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatisticDataShort : StatisticData
	{
		public new const short Id = 8387;
		public override short TypeId => Id;
		public short value { get; set; }

		public StatisticDataShort(short value)
		{
			this.value = value;
		}

		public StatisticDataShort() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadShort();
		}

	}
}
