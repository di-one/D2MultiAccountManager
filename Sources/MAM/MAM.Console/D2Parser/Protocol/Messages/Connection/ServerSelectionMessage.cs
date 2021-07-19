namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ServerSelectionMessage : NetworkMessage
	{
		public const uint Id = 6327;
		public override uint MessageId => Id;
		public ushort serverId { get; set; }

		public ServerSelectionMessage(ushort serverId)
		{
			this.serverId = serverId;
		}

		public ServerSelectionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(serverId);
		}

		public override void Deserialize(IDataReader reader)
		{
			serverId = reader.ReadVarUShort();
		}

	}
}
