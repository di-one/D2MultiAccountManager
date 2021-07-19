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
	public class UpdateMapPlayersAgressableStatusMessage : NetworkMessage
	{
		public const uint Id = 8171;
		public override uint MessageId => Id;
		public IEnumerable<ulong> playerIds { get; set; }
		public IEnumerable<byte> enable { get; set; }

		public UpdateMapPlayersAgressableStatusMessage(IEnumerable<ulong> playerIds, IEnumerable<byte> enable)
		{
			this.playerIds = playerIds;
			this.enable = enable;
		}

		public UpdateMapPlayersAgressableStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)playerIds.Count());
			foreach (var objectToSend in playerIds)
            {
				writer.WriteVarULong(objectToSend);
			}
			writer.WriteShort((short)enable.Count());
			foreach (var objectToSend in enable)
            {
				writer.WriteByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var playerIdsCount = reader.ReadUShort();
			var playerIds_ = new ulong[playerIdsCount];
			for (var playerIdsIndex = 0; playerIdsIndex < playerIdsCount; playerIdsIndex++)
			{
				playerIds_[playerIdsIndex] = reader.ReadVarULong();
			}
			playerIds = playerIds_;
			var enableCount = reader.ReadUShort();
			var enable_ = new byte[enableCount];
			for (var enableIndex = 0; enableIndex < enableCount; enableIndex++)
			{
				enable_[enableIndex] = reader.ReadByte();
			}
			enable = enable_;
		}

	}
}
