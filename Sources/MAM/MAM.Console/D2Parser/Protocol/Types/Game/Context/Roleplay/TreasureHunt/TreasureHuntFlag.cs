namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TreasureHuntFlag
	{
		public const short Id  = 7790;
		public virtual short TypeId => Id;
		public double mapId { get; set; }
		public sbyte state { get; set; }

		public TreasureHuntFlag(double mapId, sbyte state)
		{
			this.mapId = mapId;
			this.state = state;
		}

		public TreasureHuntFlag() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(mapId);
			writer.WriteSByte(state);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			mapId = reader.ReadDouble();
			state = reader.ReadSByte();
		}

	}
}
