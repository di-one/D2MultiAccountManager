namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ActivityHideRequestMessage : NetworkMessage
	{
		public const uint Id = 1908;
		public override uint MessageId => Id;
		public ushort activityId { get; set; }

		public ActivityHideRequestMessage(ushort activityId)
		{
			this.activityId = activityId;
		}

		public ActivityHideRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(activityId);
		}

		public override void Deserialize(IDataReader reader)
		{
			activityId = reader.ReadVarUShort();
		}

	}
}
