namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapRunningFightDetailsRequestMessage : NetworkMessage
	{
		public const uint Id = 3527;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }

		public MapRunningFightDetailsRequestMessage(ushort fightId)
		{
			this.fightId = fightId;
		}

		public MapRunningFightDetailsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
		}

	}
}
