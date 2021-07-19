namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismSettingsRequestMessage : NetworkMessage
	{
		public const uint Id = 863;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public sbyte startDefenseTime { get; set; }

		public PrismSettingsRequestMessage(ushort subAreaId, sbyte startDefenseTime)
		{
			this.subAreaId = subAreaId;
			this.startDefenseTime = startDefenseTime;
		}

		public PrismSettingsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteSByte(startDefenseTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			startDefenseTime = reader.ReadSByte();
		}

	}
}
