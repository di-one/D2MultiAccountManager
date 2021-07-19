namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FinishMoveSetRequestMessage : NetworkMessage
	{
		public const uint Id = 1172;
		public override uint MessageId => Id;
		public int finishMoveId { get; set; }
		public bool finishMoveState { get; set; }

		public FinishMoveSetRequestMessage(int finishMoveId, bool finishMoveState)
		{
			this.finishMoveId = finishMoveId;
			this.finishMoveState = finishMoveState;
		}

		public FinishMoveSetRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(finishMoveId);
			writer.WriteBoolean(finishMoveState);
		}

		public override void Deserialize(IDataReader reader)
		{
			finishMoveId = reader.ReadInt();
			finishMoveState = reader.ReadBoolean();
		}

	}
}
