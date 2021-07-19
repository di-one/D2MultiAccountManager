namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementDetailedListRequestMessage : NetworkMessage
	{
		public const uint Id = 3488;
		public override uint MessageId => Id;
		public ushort categoryId { get; set; }

		public AchievementDetailedListRequestMessage(ushort categoryId)
		{
			this.categoryId = categoryId;
		}

		public AchievementDetailedListRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(categoryId);
		}

		public override void Deserialize(IDataReader reader)
		{
			categoryId = reader.ReadVarUShort();
		}

	}
}
