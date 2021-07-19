namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatisticDataByte : StatisticData
	{
		public new const short Id = 7726;
		public override short TypeId => Id;
		public sbyte value { get; set; }

		public StatisticDataByte(sbyte value)
		{
			this.value = value;
		}

		public StatisticDataByte() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadSByte();
		}

	}
}
