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
	public class GameRolePlayShowMultipleActorsMessage : NetworkMessage
	{
		public const uint Id = 1154;
		public override uint MessageId => Id;
		public IEnumerable<GameRolePlayActorInformations> informationsList { get; set; }

		public GameRolePlayShowMultipleActorsMessage(IEnumerable<GameRolePlayActorInformations> informationsList)
		{
			this.informationsList = informationsList;
		}

		public GameRolePlayShowMultipleActorsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)informationsList.Count());
			foreach (var objectToSend in informationsList)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var informationsListCount = reader.ReadUShort();
			var informationsList_ = new GameRolePlayActorInformations[informationsListCount];
			for (var informationsListIndex = 0; informationsListIndex < informationsListCount; informationsListIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				informationsList_[informationsListIndex] = objectToAdd;
			}
			informationsList = informationsList_;
		}

	}
}
