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
	public class EntityLook
	{
		public const short Id  = 9118;
		public virtual short TypeId => Id;
		public ushort bonesId { get; set; }
		public IEnumerable<ushort> skins { get; set; }
		public IEnumerable<int> indexedColors { get; set; }
		public IEnumerable<short> scales { get; set; }
		public IEnumerable<SubEntity> subentities { get; set; }

		public EntityLook(ushort bonesId, IEnumerable<ushort> skins, IEnumerable<int> indexedColors, IEnumerable<short> scales, IEnumerable<SubEntity> subentities)
		{
			this.bonesId = bonesId;
			this.skins = skins;
			this.indexedColors = indexedColors;
			this.scales = scales;
			this.subentities = subentities;
		}

		public EntityLook() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(bonesId);
			writer.WriteShort((short)skins.Count());
			foreach (var objectToSend in skins)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)indexedColors.Count());
			foreach (var objectToSend in indexedColors)
            {
				writer.WriteInt(objectToSend);
			}
			writer.WriteShort((short)scales.Count());
			foreach (var objectToSend in scales)
            {
				writer.WriteVarShort(objectToSend);
			}
			writer.WriteShort((short)subentities.Count());
			foreach (var objectToSend in subentities)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			bonesId = reader.ReadVarUShort();
			var skinsCount = reader.ReadUShort();
			var skins_ = new ushort[skinsCount];
			for (var skinsIndex = 0; skinsIndex < skinsCount; skinsIndex++)
			{
				skins_[skinsIndex] = reader.ReadVarUShort();
			}
			skins = skins_;
			var indexedColorsCount = reader.ReadUShort();
			var indexedColors_ = new int[indexedColorsCount];
			for (var indexedColorsIndex = 0; indexedColorsIndex < indexedColorsCount; indexedColorsIndex++)
			{
				indexedColors_[indexedColorsIndex] = reader.ReadInt();
			}
			indexedColors = indexedColors_;
			var scalesCount = reader.ReadUShort();
			var scales_ = new short[scalesCount];
			for (var scalesIndex = 0; scalesIndex < scalesCount; scalesIndex++)
			{
				scales_[scalesIndex] = reader.ReadVarShort();
			}
			scales = scales_;
			var subentitiesCount = reader.ReadUShort();
			var subentities_ = new SubEntity[subentitiesCount];
			for (var subentitiesIndex = 0; subentitiesIndex < subentitiesCount; subentitiesIndex++)
			{
				var objectToAdd = new SubEntity();
				objectToAdd.Deserialize(reader);
				subentities_[subentitiesIndex] = objectToAdd;
			}
			subentities = subentities_;
		}

	}
}
