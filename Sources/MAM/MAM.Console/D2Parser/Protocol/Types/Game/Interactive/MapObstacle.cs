namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MapObstacle
	{
		public const short Id  = 7167;
		public virtual short TypeId => Id;
		public ushort obstacleCellId { get; set; }
		public sbyte state { get; set; }

		public MapObstacle(ushort obstacleCellId, sbyte state)
		{
			this.obstacleCellId = obstacleCellId;
			this.state = state;
		}

		public MapObstacle() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(obstacleCellId);
			writer.WriteSByte(state);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			obstacleCellId = reader.ReadVarUShort();
			state = reader.ReadSByte();
		}

	}
}
