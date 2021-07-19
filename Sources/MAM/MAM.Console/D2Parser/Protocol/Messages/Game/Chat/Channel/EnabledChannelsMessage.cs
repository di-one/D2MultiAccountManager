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
	public class EnabledChannelsMessage : NetworkMessage
	{
		public const uint Id = 5294;
		public override uint MessageId => Id;
		public IEnumerable<byte> channels { get; set; }
		public IEnumerable<byte> disallowed { get; set; }

		public EnabledChannelsMessage(IEnumerable<byte> channels, IEnumerable<byte> disallowed)
		{
			this.channels = channels;
			this.disallowed = disallowed;
		}

		public EnabledChannelsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)channels.Count());
			foreach (var objectToSend in channels)
            {
				writer.WriteByte(objectToSend);
			}
			writer.WriteShort((short)disallowed.Count());
			foreach (var objectToSend in disallowed)
            {
				writer.WriteByte(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var channelsCount = reader.ReadUShort();
			var channels_ = new byte[channelsCount];
			for (var channelsIndex = 0; channelsIndex < channelsCount; channelsIndex++)
			{
				channels_[channelsIndex] = reader.ReadByte();
			}
			channels = channels_;
			var disallowedCount = reader.ReadUShort();
			var disallowed_ = new byte[disallowedCount];
			for (var disallowedIndex = 0; disallowedIndex < disallowedCount; disallowedIndex++)
			{
				disallowed_[disallowedIndex] = reader.ReadByte();
			}
			disallowed = disallowed_;
		}

	}
}
