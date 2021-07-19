namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpouseInformationsMessage : NetworkMessage
	{
		public const uint Id = 7052;
		public override uint MessageId => Id;
		public FriendSpouseInformations spouse { get; set; }

		public SpouseInformationsMessage(FriendSpouseInformations spouse)
		{
			this.spouse = spouse;
		}

		public SpouseInformationsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort(spouse.TypeId);
			spouse.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			spouse = ProtocolTypeManager.GetInstance<FriendSpouseInformations>(reader.ReadShort());
			spouse.Deserialize(reader);
		}

	}
}
