namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountFeedRequestMessage : NetworkMessage
	{
		public const uint Id = 1772;
		public override uint MessageId => Id;
		public uint mountUid { get; set; }
		public sbyte mountLocation { get; set; }
		public uint mountFoodUid { get; set; }
		public uint quantity { get; set; }

		public MountFeedRequestMessage(uint mountUid, sbyte mountLocation, uint mountFoodUid, uint quantity)
		{
			this.mountUid = mountUid;
			this.mountLocation = mountLocation;
			this.mountFoodUid = mountFoodUid;
			this.quantity = quantity;
		}

		public MountFeedRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(mountUid);
			writer.WriteSByte(mountLocation);
			writer.WriteVarUInt(mountFoodUid);
			writer.WriteVarUInt(quantity);
		}

		public override void Deserialize(IDataReader reader)
		{
			mountUid = reader.ReadVarUInt();
			mountLocation = reader.ReadSByte();
			mountFoodUid = reader.ReadVarUInt();
			quantity = reader.ReadVarUInt();
		}

	}
}
