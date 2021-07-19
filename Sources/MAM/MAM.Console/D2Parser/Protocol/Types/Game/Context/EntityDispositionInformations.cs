namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class EntityDispositionInformations
	{
		public const short Id  = 2799;
		public virtual short TypeId => Id;
		public short cellId { get; set; }
		public sbyte direction { get; set; }

		public EntityDispositionInformations(short cellId, sbyte direction)
		{
			this.cellId = cellId;
			this.direction = direction;
		}

		public EntityDispositionInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteShort(cellId);
			writer.WriteSByte(direction);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			cellId = reader.ReadShort();
			direction = reader.ReadSByte();
		}

	}
}
