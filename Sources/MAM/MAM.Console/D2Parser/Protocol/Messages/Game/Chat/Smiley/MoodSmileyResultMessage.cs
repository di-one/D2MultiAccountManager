namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MoodSmileyResultMessage : NetworkMessage
	{
		public const uint Id = 1900;
		public override uint MessageId => Id;
		public sbyte resultCode { get; set; }
		public ushort smileyId { get; set; }

		public MoodSmileyResultMessage(sbyte resultCode, ushort smileyId)
		{
			this.resultCode = resultCode;
			this.smileyId = smileyId;
		}

		public MoodSmileyResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(resultCode);
			writer.WriteVarUShort(smileyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			resultCode = reader.ReadSByte();
			smileyId = reader.ReadVarUShort();
		}

	}
}
