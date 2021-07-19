namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountInformationInPaddockRequestMessage : NetworkMessage
	{
		public const uint Id = 8490;
		public override uint MessageId => Id;
		public int mapRideId { get; set; }

		public MountInformationInPaddockRequestMessage(int mapRideId)
		{
			this.mapRideId = mapRideId;
		}

		public MountInformationInPaddockRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarInt(mapRideId);
		}

		public override void Deserialize(IDataReader reader)
		{
			mapRideId = reader.ReadVarInt();
		}

	}
}
