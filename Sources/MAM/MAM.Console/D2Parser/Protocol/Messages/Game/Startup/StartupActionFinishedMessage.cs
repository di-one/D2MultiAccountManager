namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StartupActionFinishedMessage : NetworkMessage
	{
		public const uint Id = 7629;
		public override uint MessageId => Id;
		public bool success { get; set; }
		public bool automaticAction { get; set; }
		public int actionId { get; set; }

		public StartupActionFinishedMessage(bool success, bool automaticAction, int actionId)
		{
			this.success = success;
			this.automaticAction = automaticAction;
			this.actionId = actionId;
		}

		public StartupActionFinishedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, success);
			flag = BooleanByteWrapper.SetFlag(flag, 1, automaticAction);
			writer.WriteByte(flag);
			writer.WriteInt(actionId);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			success = BooleanByteWrapper.GetFlag(flag, 0);
			automaticAction = BooleanByteWrapper.GetFlag(flag, 1);
			actionId = reader.ReadInt();
		}

	}
}
