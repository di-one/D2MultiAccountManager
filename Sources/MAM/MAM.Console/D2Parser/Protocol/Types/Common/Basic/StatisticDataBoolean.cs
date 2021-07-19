namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatisticDataBoolean : StatisticData
	{
		public new const short Id = 9792;
		public override short TypeId => Id;
		public bool value { get; set; }

		public StatisticDataBoolean(bool value)
		{
			this.value = value;
		}

		public StatisticDataBoolean() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadBoolean();
		}

	}
}
