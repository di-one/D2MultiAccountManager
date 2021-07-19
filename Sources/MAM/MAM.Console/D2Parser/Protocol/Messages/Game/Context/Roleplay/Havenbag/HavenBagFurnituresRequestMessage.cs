namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HavenBagFurnituresRequestMessage : NetworkMessage
	{
		public const uint Id = 6845;
		public override uint MessageId => Id;
		public IEnumerable<ushort> cellIds { get; set; }
		public IEnumerable<int> funitureIds { get; set; }
		public IEnumerable<byte> orientations { get; set; }

		public HavenBagFurnituresRequestMessage(IEnumerable<ushort> cellIds, IEnumerable<int> funitureIds, IEnumerable<byte> orientations)
		{
			this.cellIds = cellIds;
			this.funitureIds = funitureIds;
			this.orientations = orientations;
		}

		public HavenBagFurnituresRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)cellIds.Count());
			foreach (var objectToSend in cellIds)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)funitureIds.Count());
			foreach (var objectToSend in funitureIds)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteShort((short)orientations.Count());
			foreach (var objectToSend in orientations)
            {
				writer.WriteByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var cellIdsCount = reader.ReadUShort();
			var cellIds_ = new ushort[cellIdsCount];
			for (var cellIdsIndex = 0; cellIdsIndex < cellIdsCount; cellIdsIndex++)
			{
				cellIds_[cellIdsIndex] = reader.ReadVarUShort();
			}
			cellIds = cellIds_;
			var funitureIdsCount = reader.ReadUShort();
			var funitureIds_ = new int[funitureIdsCount];
			for (var funitureIdsIndex = 0; funitureIdsIndex < funitureIdsCount; funitureIdsIndex++)
			{
				funitureIds_[funitureIdsIndex] = reader.ReadInt();
			}
			funitureIds = funitureIds_;
			var orientationsCount = reader.ReadUShort();
			var orientations_ = new byte[orientationsCount];
			for (var orientationsIndex = 0; orientationsIndex < orientationsCount; orientationsIndex++)
			{
				orientations_[orientationsIndex] = reader.ReadByte();
			}
			orientations = orientations_;
		}

	}
}
