namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatisticDataString : StatisticData
	{
		public new const short Id = 5723;
		public override short TypeId => Id;
		public string value { get; set; }

		public StatisticDataString(string value)
		{
			this.value = value;
		}

		public StatisticDataString() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteUTF(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadUTF();
		}

	}
}
