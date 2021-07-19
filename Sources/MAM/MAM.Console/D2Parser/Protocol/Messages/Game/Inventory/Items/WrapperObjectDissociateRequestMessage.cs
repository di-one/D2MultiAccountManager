namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class WrapperObjectDissociateRequestMessage : NetworkMessage
	{
		public const uint Id = 5389;
		public override uint MessageId => Id;
		public uint hostUID { get; set; }
		public byte hostPos { get; set; }

		public WrapperObjectDissociateRequestMessage(uint hostUID, byte hostPos)
		{
			this.hostUID = hostUID;
			this.hostPos = hostPos;
		}

		public WrapperObjectDissociateRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(hostUID);
			writer.WriteByte(hostPos);
		}

		public override void Deserialize(IDataReader reader)
		{
			hostUID = reader.ReadVarUInt();
			hostPos = reader.ReadByte();
		}

	}
}
