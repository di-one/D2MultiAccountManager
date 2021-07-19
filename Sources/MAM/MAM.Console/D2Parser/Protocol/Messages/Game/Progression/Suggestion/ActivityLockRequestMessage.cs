namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ActivityLockRequestMessage : NetworkMessage
	{
		public const uint Id = 7407;
		public override uint MessageId => Id;
		public uint activityId { get; set; }
		public bool locked { get; set; }

		public ActivityLockRequestMessage(ushort activityId, bool locked)
		{
			this.activityId = activityId;
			this.locked = locked;
		}

		public ActivityLockRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarInt((int)activityId);
			writer.WriteBoolean(locked);
		}

		public override void Deserialize(IDataReader reader)
		{
			activityId = reader.ReadVarUShort();
			locked = reader.ReadBoolean();
		}

	}
}
