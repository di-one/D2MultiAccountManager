namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceInsiderPrismInformation : PrismInformation
	{
		public new const short Id = 9390;
		public override short TypeId => Id;
		public int lastTimeSlotModificationDate { get; set; }
		public uint lastTimeSlotModificationAuthorGuildId { get; set; }
		public ulong lastTimeSlotModificationAuthorId { get; set; }
		public string lastTimeSlotModificationAuthorName { get; set; }
		public IEnumerable<ObjectItem> modulesObjects { get; set; }

		public AllianceInsiderPrismInformation(sbyte @typeId, sbyte state, int nextVulnerabilityDate, int placementDate, uint rewardTokenCount, int lastTimeSlotModificationDate, uint lastTimeSlotModificationAuthorGuildId, ulong lastTimeSlotModificationAuthorId, string lastTimeSlotModificationAuthorName, IEnumerable<ObjectItem> modulesObjects)
		{
			this.@typeId = @typeId;
			this.state = state;
			this.nextVulnerabilityDate = nextVulnerabilityDate;
			this.placementDate = placementDate;
			this.rewardTokenCount = rewardTokenCount;
			this.lastTimeSlotModificationDate = lastTimeSlotModificationDate;
			this.lastTimeSlotModificationAuthorGuildId = lastTimeSlotModificationAuthorGuildId;
			this.lastTimeSlotModificationAuthorId = lastTimeSlotModificationAuthorId;
			this.lastTimeSlotModificationAuthorName = lastTimeSlotModificationAuthorName;
			this.modulesObjects = modulesObjects;
		}

		public AllianceInsiderPrismInformation() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteInt(lastTimeSlotModificationDate);
			writer.WriteVarUInt(lastTimeSlotModificationAuthorGuildId);
			writer.WriteVarULong(lastTimeSlotModificationAuthorId);
			writer.WriteUTF(lastTimeSlotModificationAuthorName);
			writer.WriteShort((short)modulesObjects.Count());
			foreach (var objectToSend in modulesObjects)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			lastTimeSlotModificationDate = reader.ReadInt();
			lastTimeSlotModificationAuthorGuildId = reader.ReadVarUInt();
			lastTimeSlotModificationAuthorId = reader.ReadVarULong();
			lastTimeSlotModificationAuthorName = reader.ReadUTF();
			var modulesObjectsCount = reader.ReadUShort();
			var modulesObjects_ = new ObjectItem[modulesObjectsCount];
			for (var modulesObjectsIndex = 0; modulesObjectsIndex < modulesObjectsCount; modulesObjectsIndex++)
			{
				var objectToAdd = new ObjectItem();
				objectToAdd.Deserialize(reader);
				modulesObjects_[modulesObjectsIndex] = objectToAdd;
			}
			modulesObjects = modulesObjects_;
		}

	}
}
