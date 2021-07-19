namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayFightRequestCanceledMessage : NetworkMessage
	{
		public const uint Id = 3985;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public double sourceId { get; set; }
		public double targetId { get; set; }

		public GameRolePlayFightRequestCanceledMessage(ushort fightId, double sourceId, double targetId)
		{
			this.fightId = fightId;
			this.sourceId = sourceId;
			this.targetId = targetId;
		}

		public GameRolePlayFightRequestCanceledMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteDouble(sourceId);
			writer.WriteDouble(targetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			sourceId = reader.ReadDouble();
			targetId = reader.ReadDouble();
		}

	}
}
