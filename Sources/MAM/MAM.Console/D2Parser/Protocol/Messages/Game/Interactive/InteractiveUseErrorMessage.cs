namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class InteractiveUseErrorMessage : NetworkMessage
	{
		public const uint Id = 5333;
		public override uint MessageId => Id;
		public uint elemId { get; set; }
		public uint skillInstanceUid { get; set; }

		public InteractiveUseErrorMessage(uint elemId, uint skillInstanceUid)
		{
			this.elemId = elemId;
			this.skillInstanceUid = skillInstanceUid;
		}

		public InteractiveUseErrorMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(elemId);
			writer.WriteVarUInt(skillInstanceUid);
		}

		public override void Deserialize(IDataReader reader)
		{
			elemId = reader.ReadVarUInt();
			skillInstanceUid = reader.ReadVarUInt();
		}

	}
}
