namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightExternalInformations
	{
		public const short Id  = 7340;
		public virtual short TypeId => Id;
		public ushort fightId { get; set; }
		public sbyte fightType { get; set; }
		public int fightStart { get; set; }
		public bool fightSpectatorLocked { get; set; }

		public FightExternalInformations(ushort fightId, sbyte fightType, int fightStart, bool fightSpectatorLocked)
		{
			this.fightId = fightId;
			this.fightType = fightType;
			this.fightStart = fightStart;
			this.fightSpectatorLocked = fightSpectatorLocked;
		}

		public FightExternalInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteSByte(fightType);
			writer.WriteInt(fightStart);
			writer.WriteBoolean(fightSpectatorLocked);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			fightType = reader.ReadSByte();
			fightStart = reader.ReadInt();
			fightSpectatorLocked = reader.ReadBoolean();
		}

	}
}
