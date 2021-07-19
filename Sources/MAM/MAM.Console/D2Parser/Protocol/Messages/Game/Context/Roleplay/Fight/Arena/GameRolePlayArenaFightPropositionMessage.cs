namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayArenaFightPropositionMessage : NetworkMessage
	{
		public const uint Id = 6895;
		public override uint MessageId => Id;
		public ushort fightId { get; set; }
		public IEnumerable<double> alliesId { get; set; }
		public ushort duration { get; set; }

		public GameRolePlayArenaFightPropositionMessage(ushort fightId, IEnumerable<double> alliesId, ushort duration)
		{
			this.fightId = fightId;
			this.alliesId = alliesId;
			this.duration = duration;
		}

		public GameRolePlayArenaFightPropositionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(fightId);
			writer.WriteShort((short)alliesId.Count());
			foreach (var objectToSend in alliesId)
            {
				writer.WriteDouble(objectToSend);
			}
			writer.WriteVarUShort(duration);
		}

		public override void Deserialize(IDataReader reader)
		{
			fightId = reader.ReadVarUShort();
			var alliesIdCount = reader.ReadUShort();
			var alliesId_ = new double[alliesIdCount];
			for (var alliesIdIndex = 0; alliesIdIndex < alliesIdCount; alliesIdIndex++)
			{
				alliesId_[alliesIdIndex] = reader.ReadDouble();
			}
			alliesId = alliesId_;
			duration = reader.ReadVarUShort();
		}

	}
}
