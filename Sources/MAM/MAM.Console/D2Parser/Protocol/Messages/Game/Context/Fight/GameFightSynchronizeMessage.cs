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
	public class GameFightSynchronizeMessage : NetworkMessage
	{
		public const uint Id = 9757;
		public override uint MessageId => Id;
		public IEnumerable<GameFightFighterInformations> fighters { get; set; }

		public GameFightSynchronizeMessage(IEnumerable<GameFightFighterInformations> fighters)
		{
			this.fighters = fighters;
		}

		public GameFightSynchronizeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)fighters.Count());
			foreach (var objectToSend in fighters)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var fightersCount = reader.ReadUShort();
			var fighters_ = new GameFightFighterInformations[fightersCount];
			for (var fightersIndex = 0; fightersIndex < fightersCount; fightersIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				fighters_[fightersIndex] = objectToAdd;
			}
			fighters = fighters_;
		}

	}
}
