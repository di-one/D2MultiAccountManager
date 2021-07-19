namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyInvitationDungeonRequestMessage : PartyInvitationRequestMessage
	{
		public new const uint Id = 1027;
		public override uint MessageId => Id;
		public ushort dungeonId { get; set; }

		public PartyInvitationDungeonRequestMessage(AbstractPlayerSearchInformation target, ushort dungeonId)
		{
			this.target = target;
			this.dungeonId = dungeonId;
		}

		public PartyInvitationDungeonRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUShort(dungeonId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			dungeonId = reader.ReadVarUShort();
		}

	}
}
