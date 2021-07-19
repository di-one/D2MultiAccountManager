namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class RecycleResultMessage : NetworkMessage
	{
		public const uint Id = 8698;
		public override uint MessageId => Id;
		public uint nuggetsForPrism { get; set; }
		public uint nuggetsForPlayer { get; set; }

		public RecycleResultMessage(uint nuggetsForPrism, uint nuggetsForPlayer)
		{
			this.nuggetsForPrism = nuggetsForPrism;
			this.nuggetsForPlayer = nuggetsForPlayer;
		}

		public RecycleResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(nuggetsForPrism);
			writer.WriteVarUInt(nuggetsForPlayer);
		}

		public override void Deserialize(IDataReader reader)
		{
			nuggetsForPrism = reader.ReadVarUInt();
			nuggetsForPlayer = reader.ReadVarUInt();
		}

	}
}
