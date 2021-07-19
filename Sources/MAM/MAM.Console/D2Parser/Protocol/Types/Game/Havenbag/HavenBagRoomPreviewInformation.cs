namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HavenBagRoomPreviewInformation
	{
		public const short Id  = 5660;
		public virtual short TypeId => Id;
		public byte roomId { get; set; }
		public sbyte themeId { get; set; }

		public HavenBagRoomPreviewInformation(byte roomId, sbyte themeId)
		{
			this.roomId = roomId;
			this.themeId = themeId;
		}

		public HavenBagRoomPreviewInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteByte(roomId);
			writer.WriteSByte(themeId);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			roomId = reader.ReadByte();
			themeId = reader.ReadSByte();
		}

	}
}
