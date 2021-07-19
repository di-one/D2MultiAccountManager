namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterCharacteristicDetailed : CharacterCharacteristic
	{
		public new const short Id = 651;
		public override short TypeId => Id;
		public short @base { get; set; }
		public short additional { get; set; }
		public short objectsAndMountBonus { get; set; }
		public short alignGiftBonus { get; set; }
		public short contextModif { get; set; }

		public CharacterCharacteristicDetailed(short characteristicId, short @base, short additional, short objectsAndMountBonus, short alignGiftBonus, short contextModif)
		{
			this.characteristicId = characteristicId;
			this.@base = @base;
			this.additional = additional;
			this.objectsAndMountBonus = objectsAndMountBonus;
			this.alignGiftBonus = alignGiftBonus;
			this.contextModif = contextModif;
		}

		public CharacterCharacteristicDetailed() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarShort(@base);
			writer.WriteVarShort(additional);
			writer.WriteVarShort(objectsAndMountBonus);
			writer.WriteVarShort(alignGiftBonus);
			writer.WriteVarShort(contextModif);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			@base = reader.ReadVarShort();
			additional = reader.ReadVarShort();
			objectsAndMountBonus = reader.ReadVarShort();
			alignGiftBonus = reader.ReadVarShort();
			contextModif = reader.ReadVarShort();
		}

	}
}
