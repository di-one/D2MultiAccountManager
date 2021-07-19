namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SymbioticObjectAssociatedMessage : NetworkMessage
	{
		public const uint Id = 3468;
		public override uint MessageId => Id;
		public uint hostUID { get; set; }

		public SymbioticObjectAssociatedMessage(uint hostUID)
		{
			this.hostUID = hostUID;
		}

		public SymbioticObjectAssociatedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(hostUID);
		}

		public override void Deserialize(IDataReader reader)
		{
			hostUID = reader.ReadVarUInt();
		}

	}
}
