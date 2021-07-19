namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntStepFollowDirectionToHint : TreasureHuntStep
	{
		public new const short Id = 9304;
		public override short TypeId => Id;
		public sbyte direction { get; set; }
		public ushort npcId { get; set; }

		public TreasureHuntStepFollowDirectionToHint(sbyte direction, ushort npcId)
		{
			this.direction = direction;
			this.npcId = npcId;
		}

		public TreasureHuntStepFollowDirectionToHint() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteSByte(direction);
			writer.WriteVarUShort(npcId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			direction = reader.ReadSByte();
			npcId = reader.ReadVarUShort();
		}

	}
}
