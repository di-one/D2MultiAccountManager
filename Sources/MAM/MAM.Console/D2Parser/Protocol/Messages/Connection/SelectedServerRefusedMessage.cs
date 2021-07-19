namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SelectedServerRefusedMessage : NetworkMessage
	{
		public const uint Id = 506;
		public override uint MessageId => Id;
		public ushort serverId { get; set; }
		public sbyte error { get; set; }
		public sbyte serverStatus { get; set; }

		public SelectedServerRefusedMessage(ushort serverId, sbyte error, sbyte serverStatus)
		{
			this.serverId = serverId;
			this.error = error;
			this.serverStatus = serverStatus;
		}

		public SelectedServerRefusedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(serverId);
			writer.WriteSByte(error);
			writer.WriteSByte(serverStatus);
		}

		public override void Deserialize(IDataReader reader)
		{
			serverId = reader.ReadVarUShort();
			error = reader.ReadSByte();
			serverStatus = reader.ReadSByte();
		}

	}
}
