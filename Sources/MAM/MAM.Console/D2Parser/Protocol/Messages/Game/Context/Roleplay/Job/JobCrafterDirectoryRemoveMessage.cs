namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobCrafterDirectoryRemoveMessage : NetworkMessage
	{
		public const uint Id = 425;
		public override uint MessageId => Id;
		public sbyte jobId { get; set; }
		public ulong playerId { get; set; }

		public JobCrafterDirectoryRemoveMessage(sbyte jobId, ulong playerId)
		{
			this.jobId = jobId;
			this.playerId = playerId;
		}

		public JobCrafterDirectoryRemoveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(jobId);
			writer.WriteVarULong(playerId);
		}

		public override void Deserialize(IDataReader reader)
		{
			jobId = reader.ReadSByte();
			playerId = reader.ReadVarULong();
		}

	}
}
