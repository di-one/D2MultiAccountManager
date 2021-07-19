namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ObjectEffectDice : ObjectEffect
	{
		public new const short Id = 7506;
		public override short TypeId => Id;
		public uint diceNum { get; set; }
		public uint diceSide { get; set; }
		public uint diceConst { get; set; }

		public ObjectEffectDice(ushort actionId, uint diceNum, uint diceSide, uint diceConst)
		{
			this.actionId = actionId;
			this.diceNum = diceNum;
			this.diceSide = diceSide;
			this.diceConst = diceConst;
		}

		public ObjectEffectDice() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(diceNum);
			writer.WriteVarUInt(diceSide);
			writer.WriteVarUInt(diceConst);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			diceNum = reader.ReadVarUInt();
			diceSide = reader.ReadVarUInt();
			diceConst = reader.ReadVarUInt();
		}

	}
}
