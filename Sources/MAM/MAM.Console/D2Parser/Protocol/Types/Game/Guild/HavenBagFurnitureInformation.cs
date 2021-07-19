namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HavenBagFurnitureInformation
	{
		public const short Id  = 8828;
		public virtual short TypeId => Id;
		public ushort cellId { get; set; }
		public int funitureId { get; set; }
		public sbyte orientation { get; set; }

		public HavenBagFurnitureInformation(ushort cellId, int funitureId, sbyte orientation)
		{
			this.cellId = cellId;
			this.funitureId = funitureId;
			this.orientation = orientation;
		}

		public HavenBagFurnitureInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(cellId);
			writer.WriteInt(funitureId);
			writer.WriteSByte(orientation);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			cellId = reader.ReadVarUShort();
			funitureId = reader.ReadInt();
			orientation = reader.ReadSByte();
		}

	}
}
