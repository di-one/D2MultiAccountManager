namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FightStartingPositions
	{
		public const short Id  = 2393;
		public virtual short TypeId => Id;
		public IEnumerable<ushort> positionsForChallengers { get; set; }
		public IEnumerable<ushort> positionsForDefenders { get; set; }

		public FightStartingPositions(IEnumerable<ushort> positionsForChallengers, IEnumerable<ushort> positionsForDefenders)
		{
			this.positionsForChallengers = positionsForChallengers;
			this.positionsForDefenders = positionsForDefenders;
		}

		public FightStartingPositions() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)positionsForChallengers.Count());
			foreach (var objectToSend in positionsForChallengers)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)positionsForDefenders.Count());
			foreach (var objectToSend in positionsForDefenders)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var positionsForChallengersCount = reader.ReadUShort();
			var positionsForChallengers_ = new ushort[positionsForChallengersCount];
			for (var positionsForChallengersIndex = 0; positionsForChallengersIndex < positionsForChallengersCount; positionsForChallengersIndex++)
			{
				positionsForChallengers_[positionsForChallengersIndex] = reader.ReadVarUShort();
			}
			positionsForChallengers = positionsForChallengers_;
			var positionsForDefendersCount = reader.ReadUShort();
			var positionsForDefenders_ = new ushort[positionsForDefendersCount];
			for (var positionsForDefendersIndex = 0; positionsForDefendersIndex < positionsForDefendersCount; positionsForDefendersIndex++)
			{
				positionsForDefenders_[positionsForDefendersIndex] = reader.ReadVarUShort();
			}
			positionsForDefenders = positionsForDefenders_;
		}

	}
}
