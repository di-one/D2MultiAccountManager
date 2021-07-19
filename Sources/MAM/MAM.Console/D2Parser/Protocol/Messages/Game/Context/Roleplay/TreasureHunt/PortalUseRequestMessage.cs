namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PortalUseRequestMessage : NetworkMessage
	{
		public const uint Id = 4571;
		public override uint MessageId => Id;
		public uint portalId { get; set; }

		public PortalUseRequestMessage(uint portalId)
		{
			this.portalId = portalId;
		}

		public PortalUseRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(portalId);
		}

		public override void Deserialize(IDataReader reader)
		{
			portalId = reader.ReadVarUInt();
		}

	}
}
