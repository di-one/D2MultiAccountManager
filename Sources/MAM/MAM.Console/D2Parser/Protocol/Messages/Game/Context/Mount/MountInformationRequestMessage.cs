namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountInformationRequestMessage : NetworkMessage
	{
		public const uint Id = 9316;
		public override uint MessageId => Id;
		public double objectId { get; set; }
		public double time { get; set; }

		public MountInformationRequestMessage(double objectId, double time)
		{
			this.objectId = objectId;
			this.time = time;
		}

		public MountInformationRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
			writer.WriteDouble(time);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
			time = reader.ReadDouble();
		}

	}
}
