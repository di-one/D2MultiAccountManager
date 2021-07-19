namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PauseDialogMessage : NetworkMessage
	{
		public const uint Id = 1952;
		public override uint MessageId => Id;
		public sbyte dialogType { get; set; }

		public PauseDialogMessage(sbyte dialogType)
		{
			this.dialogType = dialogType;
		}

		public PauseDialogMessage() { }

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
