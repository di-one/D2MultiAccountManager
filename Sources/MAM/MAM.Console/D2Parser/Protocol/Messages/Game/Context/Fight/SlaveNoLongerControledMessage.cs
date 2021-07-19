namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SlaveNoLongerControledMessage : NetworkMessage
	{
		public const uint Id = 8844;
		public override uint MessageId => Id;
		public double masterId { get; set; }
		public double slaveId { get; set; }

		public SlaveNoLongerControledMessage(double masterId, double slaveId)
		{
			this.masterId = masterId;
			this.slaveId = slaveId;
		}

		public SlaveNoLongerControledMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(masterId);
			writer.WriteDouble(slaveId);
		}

		public override void Deserialize(IDataReader reader)
		{
			masterId = reader.ReadDouble();
			slaveId = reader.ReadDouble();
		}

	}
}
