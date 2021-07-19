namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayPlayerFightRequestMessage : NetworkMessage
	{
		public const uint Id = 55;
		public override uint MessageId => Id;
		public ulong targetId { get; set; }
		public short targetCellId { get; set; }
		public bool friendly { get; set; }

		public GameRolePlayPlayerFightRequestMessage(ulong targetId, short targetCellId, bool friendly)
		{
			this.targetId = targetId;
			this.targetCellId = targetCellId;
			this.friendly = friendly;
		}

		public GameRolePlayPlayerFightRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(targetId);
			writer.WriteShort(targetCellId);
			writer.WriteBoolean(friendly);
		}

		public override void Deserialize(IDataReader reader)
		{
			targetId = reader.ReadVarULong();
			targetCellId = reader.ReadShort();
			friendly = reader.ReadBoolean();
		}

	}
}
