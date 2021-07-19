namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BasicWhoIsMessage : NetworkMessage
	{
		public const uint Id = 5025;
		public override uint MessageId => Id;
		public bool self { get; set; }
		public bool verbose { get; set; }
		public sbyte position { get; set; }
		public AccountTagInformation accountTag { get; set; }
		public int accountId { get; set; }
		public string playerName { get; set; }
		public ulong playerId { get; set; }
		public short areaId { get; set; }
		public short serverId { get; set; }
		public short originServerId { get; set; }
		public IEnumerable<AbstractSocialGroupInfos> socialGroups { get; set; }
		public sbyte playerState { get; set; }

		public BasicWhoIsMessage(bool self, bool verbose, sbyte position, AccountTagInformation accountTag, int accountId, string playerName, ulong playerId, short areaId, short serverId, short originServerId, IEnumerable<AbstractSocialGroupInfos> socialGroups, sbyte playerState)
		{
			this.self = self;
			this.verbose = verbose;
			this.position = position;
			this.accountTag = accountTag;
			this.accountId = accountId;
			this.playerName = playerName;
			this.playerId = playerId;
			this.areaId = areaId;
			this.serverId = serverId;
			this.originServerId = originServerId;
			this.socialGroups = socialGroups;
			this.playerState = playerState;
		}

		public BasicWhoIsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, self);
			flag = BooleanByteWrapper.SetFlag(flag, 1, verbose);
			writer.WriteByte(flag);
			writer.WriteSByte(position);
			accountTag.Serialize(writer);
			writer.WriteInt(accountId);
			writer.WriteUTF(playerName);
			writer.WriteVarULong(playerId);
			writer.WriteShort(areaId);
			writer.WriteShort(serverId);
			writer.WriteShort(originServerId);
			writer.WriteShort((short)socialGroups.Count());
			foreach (var objectToSend in socialGroups)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteSByte(playerState);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			self = BooleanByteWrapper.GetFlag(flag, 0);
			verbose = BooleanByteWrapper.GetFlag(flag, 1);
			position = reader.ReadSByte();
			accountTag = new AccountTagInformation();
			accountTag.Deserialize(reader);
			accountId = reader.ReadInt();
			playerName = reader.ReadUTF();
			playerId = reader.ReadVarULong();
			areaId = reader.ReadShort();
			serverId = reader.ReadShort();
			originServerId = reader.ReadShort();
			var socialGroupsCount = reader.ReadUShort();
			var socialGroups_ = new AbstractSocialGroupInfos[socialGroupsCount];
			for (var socialGroupsIndex = 0; socialGroupsIndex < socialGroupsCount; socialGroupsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<AbstractSocialGroupInfos>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				socialGroups_[socialGroupsIndex] = objectToAdd;
			}
			socialGroups = socialGroups_;
			playerState = reader.ReadSByte();
		}

	}
}
