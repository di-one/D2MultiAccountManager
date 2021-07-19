namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyFollowStatusUpdateMessage : AbstractPartyMessage
	{
		public new const uint Id = 2715;
		public override uint MessageId => Id;
		public bool success { get; set; }
		public bool isFollowed { get; set; }
		public ulong followedId { get; set; }

		public PartyFollowStatusUpdateMessage(uint partyId, bool success, bool isFollowed, ulong followedId)
		{
			this.partyId = partyId;
			this.success = success;
			this.isFollowed = isFollowed;
			this.followedId = followedId;
		}

		public PartyFollowStatusUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, success);
			flag = BooleanByteWrapper.SetFlag(flag, 1, isFollowed);
			writer.WriteByte(flag);
			writer.WriteVarULong(followedId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var flag = reader.ReadByte();
			success = BooleanByteWrapper.GetFlag(flag, 0);
			isFollowed = BooleanByteWrapper.GetFlag(flag, 1);
			followedId = reader.ReadVarULong();
		}

	}
}
