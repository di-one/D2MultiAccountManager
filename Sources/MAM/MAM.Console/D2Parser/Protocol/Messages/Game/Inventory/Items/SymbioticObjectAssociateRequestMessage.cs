namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SymbioticObjectAssociateRequestMessage : NetworkMessage
	{
		public const uint Id = 6088;
		public override uint MessageId => Id;
		public uint symbioteUID { get; set; }
		public byte symbiotePos { get; set; }
		public uint hostUID { get; set; }
		public byte hostPos { get; set; }

		public SymbioticObjectAssociateRequestMessage(uint symbioteUID, byte symbiotePos, uint hostUID, byte hostPos)
		{
			this.symbioteUID = symbioteUID;
			this.symbiotePos = symbiotePos;
			this.hostUID = hostUID;
			this.hostPos = hostPos;
		}

		public SymbioticObjectAssociateRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(symbioteUID);
			writer.WriteByte(symbiotePos);
			writer.WriteVarUInt(hostUID);
			writer.WriteByte(hostPos);
		}

		public override void Deserialize(IDataReader reader)
		{
			symbioteUID = reader.ReadVarUInt();
			symbiotePos = reader.ReadByte();
			hostUID = reader.ReadVarUInt();
			hostPos = reader.ReadByte();
		}

	}
}
