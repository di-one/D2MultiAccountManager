namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FinishMoveInformations
	{
		public const short Id  = 81;
		public virtual short TypeId => Id;
		public int finishMoveId { get; set; }
		public bool finishMoveState { get; set; }

		public FinishMoveInformations(int finishMoveId, bool finishMoveState)
		{
			this.finishMoveId = finishMoveId;
			this.finishMoveState = finishMoveState;
		}

		public FinishMoveInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(finishMoveId);
			writer.WriteBoolean(finishMoveState);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			finishMoveId = reader.ReadInt();
			finishMoveState = reader.ReadBoolean();
		}

	}
}
