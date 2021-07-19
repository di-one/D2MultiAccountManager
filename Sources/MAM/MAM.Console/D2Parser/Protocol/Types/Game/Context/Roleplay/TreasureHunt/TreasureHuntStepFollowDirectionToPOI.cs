namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntStepFollowDirectionToPOI : TreasureHuntStep
	{
		public new const short Id = 6674;
		public override short TypeId => Id;
		public sbyte direction { get; set; }
		public ushort poiLabelId { get; set; }

		public TreasureHuntStepFollowDirectionToPOI(sbyte direction, ushort poiLabelId)
		{
			this.direction = direction;
			this.poiLabelId = poiLabelId;
		}

		public TreasureHuntStepFollowDirectionToPOI() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(direction);
			writer.WriteVarUShort(poiLabelId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			direction = reader.ReadSByte();
			poiLabelId = reader.ReadVarUShort();
		}

	}
}
