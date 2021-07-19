namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InteractiveUseEndedMessage : NetworkMessage
	{
		public const uint Id = 6869;
		public override uint MessageId => Id;
		public uint elemId { get; set; }
		public ushort skillId { get; set; }

		public InteractiveUseEndedMessage(uint elemId, ushort skillId)
		{
			this.elemId = elemId;
			this.skillId = skillId;
		}

		public InteractiveUseEndedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(elemId);
			writer.WriteVarUShort(skillId);
		}

		public override void Deserialize(IDataReader reader)
		{
			elemId = reader.ReadVarUInt();
			skillId = reader.ReadVarUShort();
		}

	}
}
