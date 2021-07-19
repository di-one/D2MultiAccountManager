namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class CharacterSelectedForceMessage : NetworkMessage
	{
		public const uint Id = 621;
		public override uint MessageId => Id;
		public int objectId { get; set; }

		public CharacterSelectedForceMessage(int objectId)
		{
			this.objectId = objectId;
		}

		public CharacterSelectedForceMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadInt();
		}

	}
}
