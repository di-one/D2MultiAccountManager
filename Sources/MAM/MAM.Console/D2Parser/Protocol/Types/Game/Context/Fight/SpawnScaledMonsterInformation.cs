namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpawnScaledMonsterInformation : BaseSpawnMonsterInformation
	{
		public new const short Id = 9707;
		public override short TypeId => Id;
		public short creatureLevel { get; set; }

		public SpawnScaledMonsterInformation(ushort creatureGenericId, short creatureLevel)
		{
			this.creatureGenericId = creatureGenericId;
			this.creatureLevel = creatureLevel;
		}

		public SpawnScaledMonsterInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(creatureLevel);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			creatureLevel = reader.ReadShort();
		}

	}
}
