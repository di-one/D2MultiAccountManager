namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class UpdateSelfAgressableStatusMessage : NetworkMessage
	{
		public const uint Id = 3063;
		public override uint MessageId => Id;
		public sbyte status { get; set; }
		public int probationTime { get; set; }

		public UpdateSelfAgressableStatusMessage(sbyte status, int probationTime)
		{
			this.status = status;
			this.probationTime = probationTime;
		}

		public UpdateSelfAgressableStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(status);
			writer.WriteInt(probationTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			status = reader.ReadSByte();
			probationTime = reader.ReadInt();
		}

	}
}
