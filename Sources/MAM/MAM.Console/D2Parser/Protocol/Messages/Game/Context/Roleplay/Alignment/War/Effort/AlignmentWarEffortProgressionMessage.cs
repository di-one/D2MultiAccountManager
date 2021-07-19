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
	public class AlignmentWarEffortProgressionMessage : NetworkMessage
	{
		public const uint Id = 8318;
		public override uint MessageId => Id;
		public IEnumerable<AlignmentWarEffortInformation> effortProgressions { get; set; }

		public AlignmentWarEffortProgressionMessage(IEnumerable<AlignmentWarEffortInformation> effortProgressions)
		{
			this.effortProgressions = effortProgressions;
		}

		public AlignmentWarEffortProgressionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)effortProgressions.Count());
			foreach (var objectToSend in effortProgressions)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var effortProgressionsCount = reader.ReadUShort();
			var effortProgressions_ = new AlignmentWarEffortInformation[effortProgressionsCount];
			for (var effortProgressionsIndex = 0; effortProgressionsIndex < effortProgressionsCount; effortProgressionsIndex++)
			{
				var objectToAdd = new AlignmentWarEffortInformation();
				objectToAdd.Deserialize(reader);
				effortProgressions_[effortProgressionsIndex] = objectToAdd;
			}
			effortProgressions = effortProgressions_;
		}

	}
}
