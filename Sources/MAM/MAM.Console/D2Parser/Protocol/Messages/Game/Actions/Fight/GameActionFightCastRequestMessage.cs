namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightCastRequestMessage : NetworkMessage
	{
		public const uint Id = 5437;
		public override uint MessageId => Id;
		public ushort spellId { get; set; }
		public short cellId { get; set; }

		public GameActionFightCastRequestMessage(ushort spellId, short cellId)
		{
			this.spellId = spellId;
			this.cellId = cellId;
		}

		public GameActionFightCastRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(spellId);
			writer.WriteShort(cellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			spellId = reader.ReadVarUShort();
			cellId = reader.ReadShort();
		}

	}
}
