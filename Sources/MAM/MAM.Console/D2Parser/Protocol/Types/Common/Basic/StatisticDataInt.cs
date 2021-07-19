namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatisticDataInt : StatisticData
	{
		public new const short Id = 9200;
		public override short TypeId => Id;
		public int value { get; set; }

		public StatisticDataInt(int value)
		{
			this.value = value;
		}

		public StatisticDataInt() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadInt();
		}

	}
}
