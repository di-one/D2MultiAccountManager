namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MimicryObjectFeedAndAssociateRequestMessage : SymbioticObjectAssociateRequestMessage
	{
		public new const uint Id = 5440;
		public override uint MessageId => Id;
		public uint foodUID { get; set; }
		public byte foodPos { get; set; }
		public bool preview { get; set; }

		public MimicryObjectFeedAndAssociateRequestMessage(uint symbioteUID, byte symbiotePos, uint hostUID, byte hostPos, uint foodUID, byte foodPos, bool preview)
		{
			this.symbioteUID = symbioteUID;
			this.symbiotePos = symbiotePos;
			this.hostUID = hostUID;
			this.hostPos = hostPos;
			this.foodUID = foodUID;
			this.foodPos = foodPos;
			this.preview = preview;
		}

		public MimicryObjectFeedAndAssociateRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(foodUID);
			writer.WriteByte(foodPos);
			writer.WriteBoolean(preview);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			foodUID = reader.ReadVarUInt();
			foodPos = reader.ReadByte();
			preview = reader.ReadBoolean();
		}

	}
}
