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
	public class StartupActionsListMessage : NetworkMessage
	{
		public const uint Id = 9717;
		public override uint MessageId => Id;
		public IEnumerable<StartupActionAddObject> actions { get; set; }

		public StartupActionsListMessage(IEnumerable<StartupActionAddObject> actions)
		{
			this.actions = actions;
		}

		public StartupActionsListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)actions.Count());
			foreach (var objectToSend in actions)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var actionsCount = reader.ReadUShort();
			var actions_ = new StartupActionAddObject[actionsCount];
			for (var actionsIndex = 0; actionsIndex < actionsCount; actionsIndex++)
			{
				var objectToAdd = new StartupActionAddObject();
				objectToAdd.Deserialize(reader);
				actions_[actionsIndex] = objectToAdd;
			}
			actions = actions_;
		}

	}
}
