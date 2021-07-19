namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightEntityDispositionInformations : EntityDispositionInformations
	{
		public new const short Id = 2973;
		public override short TypeId => Id;
		public double carryingCharacterId { get; set; }

		public FightEntityDispositionInformations(short cellId, sbyte direction, double carryingCharacterId)
		{
			this.cellId = cellId;
			this.direction = direction;
			this.carryingCharacterId = carryingCharacterId;
		}

		public FightEntityDispositionInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(carryingCharacterId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			carryingCharacterId = reader.ReadDouble();
		}

	}
}
