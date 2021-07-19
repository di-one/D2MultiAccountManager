namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ServerSessionConstantLong : ServerSessionConstant
	{
		public new const short Id = 1271;
		public override short TypeId => Id;
		public double value { get; set; }

		public ServerSessionConstantLong(ushort objectId, double value)
		{
			this.objectId = objectId;
			this.value = value;
		}

		public ServerSessionConstantLong() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(value);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			value = reader.ReadDouble();
		}

	}
}
