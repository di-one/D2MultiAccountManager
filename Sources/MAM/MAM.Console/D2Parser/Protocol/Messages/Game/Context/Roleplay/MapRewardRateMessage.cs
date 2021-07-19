namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapRewardRateMessage : NetworkMessage
	{
		public const uint Id = 3807;
		public override uint MessageId => Id;
		public short mapRate { get; set; }
		public short subAreaRate { get; set; }
		public short totalRate { get; set; }

		public MapRewardRateMessage(short mapRate, short subAreaRate, short totalRate)
		{
			this.mapRate = mapRate;
			this.subAreaRate = subAreaRate;
			this.totalRate = totalRate;
		}

		public MapRewardRateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarShort(mapRate);
			writer.WriteVarShort(subAreaRate);
			writer.WriteVarShort(totalRate);
		}

		public override void Deserialize(IDataReader reader)
		{
			mapRate = reader.ReadVarShort();
			subAreaRate = reader.ReadVarShort();
			totalRate = reader.ReadVarShort();
		}

	}
}
