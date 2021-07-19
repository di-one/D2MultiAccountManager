namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorMovementMessage : NetworkMessage
	{
		public const uint Id = 4295;
		public override uint MessageId => Id;
		public sbyte movementType { get; set; }
		public TaxCollectorBasicInformations basicInfos { get; set; }
		public ulong playerId { get; set; }
		public string playerName { get; set; }

		public TaxCollectorMovementMessage(sbyte movementType, TaxCollectorBasicInformations basicInfos, ulong playerId, string playerName)
		{
			this.movementType = movementType;
			this.basicInfos = basicInfos;
			this.playerId = playerId;
			this.playerName = playerName;
		}

		public TaxCollectorMovementMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(movementType);
			basicInfos.Serialize(writer);
			writer.WriteVarULong(playerId);
			writer.WriteUTF(playerName);
		}

		public override void Deserialize(IDataReader reader)
		{
			movementType = reader.ReadSByte();
			basicInfos = new TaxCollectorBasicInformations();
			basicInfos.Deserialize(reader);
			playerId = reader.ReadVarULong();
			playerName = reader.ReadUTF();
		}

	}
}
