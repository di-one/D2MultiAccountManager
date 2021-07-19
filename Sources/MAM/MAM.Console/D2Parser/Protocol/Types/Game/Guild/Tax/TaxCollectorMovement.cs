namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorMovement
	{
		public const short Id  = 4904;
		public virtual short TypeId => Id;
		public sbyte movementType { get; set; }
		public TaxCollectorBasicInformations basicInfos { get; set; }
		public ulong playerId { get; set; }
		public string playerName { get; set; }

		public TaxCollectorMovement(sbyte movementType, TaxCollectorBasicInformations basicInfos, ulong playerId, string playerName)
		{
			this.movementType = movementType;
			this.basicInfos = basicInfos;
			this.playerId = playerId;
			this.playerName = playerName;
		}

		public TaxCollectorMovement() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(movementType);
			basicInfos.Serialize(writer);
			writer.WriteVarULong(playerId);
			writer.WriteUTF(playerName);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			movementType = reader.ReadSByte();
			basicInfos = new TaxCollectorBasicInformations();
			basicInfos.Deserialize(reader);
			playerId = reader.ReadVarULong();
			playerName = reader.ReadUTF();
		}

	}
}
