namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StatsUpgradeResultMessage : NetworkMessage
	{
		public const uint Id = 5570;
		public override uint MessageId => Id;
		public sbyte result { get; set; }
		public ushort nbCharacBoost { get; set; }

		public StatsUpgradeResultMessage(sbyte result, ushort nbCharacBoost)
		{
			this.result = result;
			this.nbCharacBoost = nbCharacBoost;
		}

		public StatsUpgradeResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(result);
			writer.WriteVarUShort(nbCharacBoost);
		}

		public override void Deserialize(IDataReader reader)
		{
			result = reader.ReadSByte();
			nbCharacBoost = reader.ReadVarUShort();
		}

	}
}
