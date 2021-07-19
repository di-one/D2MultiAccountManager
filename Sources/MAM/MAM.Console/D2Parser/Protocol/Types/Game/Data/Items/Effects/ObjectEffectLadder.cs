namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffectLadder : ObjectEffectCreature
	{
		public new const short Id = 2694;
		public override short TypeId => Id;
		public uint monsterCount { get; set; }

		public ObjectEffectLadder(ushort actionId, ushort monsterFamilyId, uint monsterCount)
		{
			this.actionId = actionId;
			this.monsterFamilyId = monsterFamilyId;
			this.monsterCount = monsterCount;
		}

		public ObjectEffectLadder() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(monsterCount);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			monsterCount = reader.ReadVarUInt();
		}

	}
}
