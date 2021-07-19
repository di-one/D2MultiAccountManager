namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismSetSabotagedRequestMessage : NetworkMessage
	{
		public const uint Id = 9811;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }

		public PrismSetSabotagedRequestMessage(ushort subAreaId)
		{
			this.subAreaId = subAreaId;
		}

		public PrismSetSabotagedRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
		}

	}
}
