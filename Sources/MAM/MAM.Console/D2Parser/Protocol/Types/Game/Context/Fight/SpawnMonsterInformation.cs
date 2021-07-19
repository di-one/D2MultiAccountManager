namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpawnMonsterInformation : BaseSpawnMonsterInformation
	{
		public new const short Id = 3997;
		public override short TypeId => Id;
		public sbyte creatureGrade { get; set; }

		public SpawnMonsterInformation(ushort creatureGenericId, sbyte creatureGrade)
		{
			this.creatureGenericId = creatureGenericId;
			this.creatureGrade = creatureGrade;
		}

		public SpawnMonsterInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(creatureGrade);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			creatureGrade = reader.ReadSByte();
		}

	}
}
