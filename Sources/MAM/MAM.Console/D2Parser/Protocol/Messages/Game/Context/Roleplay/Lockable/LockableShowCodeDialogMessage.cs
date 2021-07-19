namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LockableShowCodeDialogMessage : NetworkMessage
	{
		public const uint Id = 5688;
		public override uint MessageId => Id;
		public bool changeOrUse { get; set; }
		public sbyte codeSize { get; set; }

		public LockableShowCodeDialogMessage(bool changeOrUse, sbyte codeSize)
		{
			this.changeOrUse = changeOrUse;
			this.codeSize = codeSize;
		}

		public LockableShowCodeDialogMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(changeOrUse);
			writer.WriteSByte(codeSize);
		}

		public override void Deserialize(IDataReader reader)
		{
			changeOrUse = reader.ReadBoolean();
			codeSize = reader.ReadSByte();
		}

	}
}
