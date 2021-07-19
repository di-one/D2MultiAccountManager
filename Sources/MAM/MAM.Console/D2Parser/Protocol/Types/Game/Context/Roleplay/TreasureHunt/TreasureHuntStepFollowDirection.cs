namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntStepFollowDirection : TreasureHuntStep
	{
		public new const short Id = 3436;
		public override short TypeId => Id;
		public sbyte direction { get; set; }
		public ushort mapCount { get; set; }

		public TreasureHuntStepFollowDirection(sbyte direction, ushort mapCount)
		{
			this.direction = direction;
			this.mapCount = mapCount;
		}

		public TreasureHuntStepFollowDirection() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(direction);
			writer.WriteVarUShort(mapCount);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			direction = reader.ReadSByte();
			mapCount = reader.ReadVarUShort();
		}

	}
}
