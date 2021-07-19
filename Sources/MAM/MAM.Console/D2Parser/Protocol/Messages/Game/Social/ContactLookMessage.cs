namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ContactLookMessage : NetworkMessage
	{
		public const uint Id = 4599;
		public override uint MessageId => Id;
		public uint requestId { get; set; }
		public string playerName { get; set; }
		public ulong playerId { get; set; }
		public EntityLook look { get; set; }

		public ContactLookMessage(uint requestId, string playerName, ulong playerId, EntityLook look)
		{
			this.requestId = requestId;
			this.playerName = playerName;
			this.playerId = playerId;
			this.look = look;
		}

		public ContactLookMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(requestId);
			writer.WriteUTF(playerName);
			writer.WriteVarULong(playerId);
			look.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			requestId = reader.ReadVarUInt();
			playerName = reader.ReadUTF();
			playerId = reader.ReadVarULong();
			look = new EntityLook();
			look.Deserialize(reader);
		}

	}
}
