namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightTurnStartMessage : NetworkMessage
	{
		public const uint Id = 1672;
		public override uint MessageId => Id;
		public double objectId { get; set; }
		public uint waitTime { get; set; }

		public GameFightTurnStartMessage(double objectId, uint waitTime)
		{
			this.objectId = objectId;
			this.waitTime = waitTime;
		}

		public GameFightTurnStartMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(objectId);
			writer.WriteVarUInt(waitTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadDouble();
			waitTime = reader.ReadVarUInt();
		}

	}
}
