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
	public class TreasureHuntMessage : NetworkMessage
	{
		public const uint Id = 3778;
		public override uint MessageId => Id;
		public sbyte questType { get; set; }
		public double startMapId { get; set; }
		public IEnumerable<TreasureHuntStep> knownStepsList { get; set; }
		public sbyte totalStepCount { get; set; }
		public uint checkPointCurrent { get; set; }
		public uint checkPointTotal { get; set; }
		public int availableRetryCount { get; set; }
		public IEnumerable<TreasureHuntFlag> flags { get; set; }

		public TreasureHuntMessage(sbyte questType, double startMapId, IEnumerable<TreasureHuntStep> knownStepsList, sbyte totalStepCount, uint checkPointCurrent, uint checkPointTotal, int availableRetryCount, IEnumerable<TreasureHuntFlag> flags)
		{
			this.questType = questType;
			this.startMapId = startMapId;
			this.knownStepsList = knownStepsList;
			this.totalStepCount = totalStepCount;
			this.checkPointCurrent = checkPointCurrent;
			this.checkPointTotal = checkPointTotal;
			this.availableRetryCount = availableRetryCount;
			this.flags = flags;
		}

		public TreasureHuntMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(questType);
			writer.WriteDouble(startMapId);
			writer.WriteShort((short)knownStepsList.Count());
			foreach (var objectToSend in knownStepsList)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteSByte(totalStepCount);
			writer.WriteVarUInt(checkPointCurrent);
			writer.WriteVarUInt(checkPointTotal);
			writer.WriteInt(availableRetryCount);
			writer.WriteShort((short)flags.Count());
			foreach (var objectToSend in flags)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			questType = reader.ReadSByte();
			startMapId = reader.ReadDouble();
			var knownStepsListCount = reader.ReadUShort();
			var knownStepsList_ = new TreasureHuntStep[knownStepsListCount];
			for (var knownStepsListIndex = 0; knownStepsListIndex < knownStepsListCount; knownStepsListIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<TreasureHuntStep>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				knownStepsList_[knownStepsListIndex] = objectToAdd;
			}
			knownStepsList = knownStepsList_;
			totalStepCount = reader.ReadSByte();
			checkPointCurrent = reader.ReadVarUInt();
			checkPointTotal = reader.ReadVarUInt();
			availableRetryCount = reader.ReadInt();
			var flagsCount = reader.ReadUShort();
			var flags_ = new TreasureHuntFlag[flagsCount];
			for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++)
			{
				var objectToAdd = new TreasureHuntFlag();
				objectToAdd.Deserialize(reader);
				flags_[flagsIndex] = objectToAdd;
			}
			flags = flags_;
		}

	}
}
