namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MoodSmileyRequestMessage : NetworkMessage
	{
		public const uint Id = 9152;
		public override uint MessageId => Id;
		public ushort smileyId { get; set; }

		public MoodSmileyRequestMessage(ushort smileyId)
		{
			this.smileyId = smileyId;
		}

		public MoodSmileyRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(smileyId);
		}

		public override void Deserialize(IDataReader reader)
		{
			smileyId = reader.ReadVarUShort();
		}

	}
}
