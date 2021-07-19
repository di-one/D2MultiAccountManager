namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LeaveDialogMessage : NetworkMessage
	{
		public const uint Id = 7199;
		public override uint MessageId => Id;
		public sbyte dialogType { get; set; }

		public LeaveDialogMessage(sbyte dialogType)
		{
			this.dialogType = dialogType;
		}

		public LeaveDialogMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(dialogType);
		}

		public override void Deserialize(IDataReader reader)
		{
			dialogType = reader.ReadSByte();
		}

	}
}
