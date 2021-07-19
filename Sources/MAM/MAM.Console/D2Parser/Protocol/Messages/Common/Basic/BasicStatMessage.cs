namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicStatMessage : NetworkMessage
	{
		public const uint Id = 9670;
		public override uint MessageId => Id;
		public double timeSpent { get; set; }
		public ushort statId { get; set; }

		public BasicStatMessage(double timeSpent, ushort statId)
		{
			this.timeSpent = timeSpent;
			this.statId = statId;
		}

		public BasicStatMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(timeSpent);
			writer.WriteVarUShort(statId);
		}

		public override void Deserialize(IDataReader reader)
		{
			timeSpent = reader.ReadDouble();
			statId = reader.ReadVarUShort();
		}

	}
}
