namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BaseSpawnMonsterInformation : SpawnInformation
	{
		public new const short Id = 5895;
		public override short TypeId => Id;
		public ushort creatureGenericId { get; set; }

		public BaseSpawnMonsterInformation(ushort creatureGenericId)
		{
			this.creatureGenericId = creatureGenericId;
		}

		public BaseSpawnMonsterInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(creatureGenericId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			creatureGenericId = reader.ReadVarUShort();
		}

	}
}
