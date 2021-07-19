namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryEntryRequestMessage : NetworkMessage
	{
		public const uint Id = 9302;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }

		public JobCrafterDirectoryEntryRequestMessage(ulong playerId)
		{
			this.playerId = playerId;
		}

		public JobCrafterDirectoryEntryRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			playerId = reader.ReadVarULong();
		}

	}
}
