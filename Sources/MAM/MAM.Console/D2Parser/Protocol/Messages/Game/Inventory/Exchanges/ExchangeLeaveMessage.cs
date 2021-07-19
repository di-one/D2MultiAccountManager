namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ExchangeLeaveMessage : LeaveDialogMessage
	{
		public new const uint Id = 7647;
		public override uint MessageId => Id;
		public bool success { get; set; }

		public ExchangeLeaveMessage(sbyte dialogType, bool success)
		{
			this.dialogType = dialogType;
			this.success = success;
		}

		public ExchangeLeaveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteBoolean(success);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			success = reader.ReadBoolean();
		}

	}
}
