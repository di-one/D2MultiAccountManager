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
	public class TaxCollectorInformations
	{
		public const short Id  = 6718;
		public virtual short TypeId => Id;
		public double uniqueId { get; set; }
		public ushort firtNameId { get; set; }
		public ushort lastNameId { get; set; }
		public AdditionalTaxCollectorInformations additionalInfos { get; set; }
		public short worldX { get; set; }
		public short worldY { get; set; }
		public ushort subAreaId { get; set; }
		public sbyte state { get; set; }
		public EntityLook look { get; set; }
		public IEnumerable<TaxCollectorComplementaryInformations> complements { get; set; }

		public TaxCollectorInformations(double uniqueId, ushort firtNameId, ushort lastNameId, AdditionalTaxCollectorInformations additionalInfos, short worldX, short worldY, ushort subAreaId, sbyte state, EntityLook look, IEnumerable<TaxCollectorComplementaryInformations> complements)
		{
			this.uniqueId = uniqueId;
			this.firtNameId = firtNameId;
			this.lastNameId = lastNameId;
			this.additionalInfos = additionalInfos;
			this.worldX = worldX;
			this.worldY = worldY;
			this.subAreaId = subAreaId;
			this.state = state;
			this.look = look;
			this.complements = complements;
		}

		public TaxCollectorInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(uniqueId);
			writer.WriteVarUShort(firtNameId);
			writer.WriteVarUShort(lastNameId);
			additionalInfos.Serialize(writer);
			writer.WriteShort(worldX);
			writer.WriteShort(worldY);
			writer.WriteVarUShort(subAreaId);
			writer.WriteSByte(state);
			look.Serialize(writer);
			writer.WriteShort((short)complements.Count());
			foreach (var objectToSend in complements)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			uniqueId = reader.ReadDouble();
			firtNameId = reader.ReadVarUShort();
			lastNameId = reader.ReadVarUShort();
			additionalInfos = new AdditionalTaxCollectorInformations();
			additionalInfos.Deserialize(reader);
			worldX = reader.ReadShort();
			worldY = reader.ReadShort();
			subAreaId = reader.ReadVarUShort();
			state = reader.ReadSByte();
			look = new EntityLook();
			look.Deserialize(reader);
			var complementsCount = reader.ReadUShort();
			var complements_ = new TaxCollectorComplementaryInformations[complementsCount];
			for (var complementsIndex = 0; complementsIndex < complementsCount; complementsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<TaxCollectorComplementaryInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				complements_[complementsIndex] = objectToAdd;
			}
			complements = complements_;
		}

	}
}
