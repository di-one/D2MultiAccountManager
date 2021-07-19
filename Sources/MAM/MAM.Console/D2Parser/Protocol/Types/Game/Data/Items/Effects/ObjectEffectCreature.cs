namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffectCreature : ObjectEffect
	{
		public new const short Id = 222;
		public override short TypeId => Id;
		public ushort monsterFamilyId { get; set; }

		public ObjectEffectCreature(ushort actionId, ushort monsterFamilyId)
		{
			this.actionId = actionId;
			this.monsterFamilyId = monsterFamilyId;
		}

		public ObjectEffectCreature() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(monsterFamilyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			monsterFamilyId = reader.ReadVarUShort();
		}

	}
}
