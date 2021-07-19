namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameDataPaddockObjectRemoveMessage : NetworkMessage
	{
		public const uint Id = 3645;
		public override uint MessageId => Id;
		public ushort cellId { get; set; }

		public GameDataPaddockObjectRemoveMessage(ushort cellId)
		{
			this.cellId = cellId;
		}

		public GameDataPaddockObjectRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(cellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			cellId = reader.ReadVarUShort();
		}

	}
}
