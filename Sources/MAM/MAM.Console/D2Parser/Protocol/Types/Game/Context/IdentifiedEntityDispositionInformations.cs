namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class IdentifiedEntityDispositionInformations : EntityDispositionInformations
	{
		public new const short Id = 9489;
		public override short TypeId => Id;
		public double objectId { get; set; }

		public IdentifiedEntityDispositionInformations(short cellId, sbyte direction, double objectId)
		{
			this.cellId = cellId;
			this.direction = direction;
			this.objectId = objectId;
		}

		public IdentifiedEntityDispositionInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteDouble(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			objectId = reader.ReadDouble();
		}

	}
}
