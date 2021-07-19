namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
	{
		public new const uint Id = 915;
		public override uint MessageId => Id;
		public uint houseId { get; set; }
		public int instanceId { get; set; }
		public bool secondHand { get; set; }

		public LockableStateUpdateHouseDoorMessage(bool locked, uint houseId, int instanceId, bool secondHand)
		{
			this.locked = locked;
			this.houseId = houseId;
			this.instanceId = instanceId;
			this.secondHand = secondHand;
		}

		public LockableStateUpdateHouseDoorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(houseId);
			writer.WriteInt(instanceId);
			writer.WriteBoolean(secondHand);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			houseId = reader.ReadVarUInt();
			instanceId = reader.ReadInt();
			secondHand = reader.ReadBoolean();
		}

	}
}
