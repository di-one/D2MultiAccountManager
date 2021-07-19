namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountRidingMessage : NetworkMessage
	{
		public const uint Id = 8975;
		public override uint MessageId => Id;
		public bool isRiding { get; set; }
		public bool isAutopilot { get; set; }

		public MountRidingMessage(bool isRiding, bool isAutopilot)
		{
			this.isRiding = isRiding;
			this.isAutopilot = isAutopilot;
		}

		public MountRidingMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, isRiding);
			flag = BooleanByteWrapper.SetFlag(flag, 1, isAutopilot);
			writer.WriteByte(flag);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			isRiding = BooleanByteWrapper.GetFlag(flag, 0);
			isAutopilot = BooleanByteWrapper.GetFlag(flag, 1);
		}

	}
}
