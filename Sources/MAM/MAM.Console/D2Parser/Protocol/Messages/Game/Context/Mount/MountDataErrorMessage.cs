namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountDataErrorMessage : NetworkMessage
	{
		public const uint Id = 4449;
		public override uint MessageId => Id;
		public sbyte reason { get; set; }

		public MountDataErrorMessage(sbyte reason)
		{
			this.reason = reason;
		}

		public MountDataErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(reason);
		}

		public override void Deserialize(IDataReader reader)
		{
			reason = reader.ReadSByte();
		}

	}
}
