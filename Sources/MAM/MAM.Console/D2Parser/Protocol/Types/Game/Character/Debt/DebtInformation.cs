namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DebtInformation
	{
		public const short Id  = 7005;
		public virtual short TypeId => Id;
		public double objectId { get; set; }
		public double timestamp { get; set; }

		public DebtInformation(double objectId, double timestamp)
		{
			this.objectId = objectId;
			this.timestamp = timestamp;
		}

		public DebtInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
			writer.WriteDouble(timestamp);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
			timestamp = reader.ReadDouble();
		}

	}
}
