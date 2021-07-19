namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseInstanceInformations
	{
		public const short Id  = 4670;
		public virtual short TypeId => Id;
		public bool secondHand { get; set; }
		public bool isLocked { get; set; }
		public bool hasOwner { get; set; }
		public bool isSaleLocked { get; set; }
		public int instanceId { get; set; }
		public AccountTagInformation ownerTag { get; set; }
		public long price { get; set; }

		public HouseInstanceInformations(bool secondHand, bool isLocked, bool hasOwner, bool isSaleLocked, int instanceId, AccountTagInformation ownerTag, long price)
		{
			this.secondHand = secondHand;
			this.isLocked = isLocked;
			this.hasOwner = hasOwner;
			this.isSaleLocked = isSaleLocked;
			this.instanceId = instanceId;
			this.ownerTag = ownerTag;
			this.price = price;
		}

		public HouseInstanceInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, secondHand);
			flag = BooleanByteWrapper.SetFlag(flag, 1, isLocked);
			flag = BooleanByteWrapper.SetFlag(flag, 2, hasOwner);
			flag = BooleanByteWrapper.SetFlag(flag, 3, isSaleLocked);
			writer.WriteByte(flag);
			writer.WriteInt(instanceId);
			ownerTag.Serialize(writer);
			writer.WriteVarLong(price);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			secondHand = BooleanByteWrapper.GetFlag(flag, 0);
			isLocked = BooleanByteWrapper.GetFlag(flag, 1);
			hasOwner = BooleanByteWrapper.GetFlag(flag, 2);
			isSaleLocked = BooleanByteWrapper.GetFlag(flag, 3);
			instanceId = reader.ReadInt();
			ownerTag = new AccountTagInformation();
			ownerTag.Deserialize(reader);
			price = reader.ReadVarLong();
		}

	}
}
