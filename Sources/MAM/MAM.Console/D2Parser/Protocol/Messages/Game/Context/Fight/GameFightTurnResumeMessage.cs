namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightTurnResumeMessage : GameFightTurnStartMessage
	{
		public new const uint Id = 373;
		public override uint MessageId => Id;
		public uint remainingTime { get; set; }

		public GameFightTurnResumeMessage(double objectId, uint waitTime, uint remainingTime)
		{
			this.objectId = objectId;
			this.waitTime = waitTime;
			this.remainingTime = remainingTime;
		}

		public GameFightTurnResumeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(remainingTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			remainingTime = reader.ReadVarUInt();
		}

	}
}
