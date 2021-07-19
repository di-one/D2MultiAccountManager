namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AllianceKickRequestMessage : NetworkMessage
	{
		public const uint Id = 7504;
		public override uint MessageId => Id;
		public uint kickedId { get; set; }

		public AllianceKickRequestMessage(uint kickedId)
		{
			this.kickedId = kickedId;
		}

		public AllianceKickRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(kickedId);
		}

		public override void Deserialize(IDataReader reader)
		{
			kickedId = reader.ReadVarUInt();
		}

	}
}
