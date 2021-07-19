namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class NotificationUpdateFlagMessage : NetworkMessage
	{
		public const uint Id = 552;
		public override uint MessageId => Id;
		public ushort index { get; set; }

		public NotificationUpdateFlagMessage(ushort index)
		{
			this.index = index;
		}

		public NotificationUpdateFlagMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(index);
		}

		public override void Deserialize(IDataReader reader)
		{
			index = reader.ReadVarUShort();
		}

	}
}
