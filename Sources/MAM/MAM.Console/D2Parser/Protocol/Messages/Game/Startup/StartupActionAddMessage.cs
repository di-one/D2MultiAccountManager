namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class StartupActionAddMessage : NetworkMessage
	{
		public const uint Id = 2141;
		public override uint MessageId => Id;
		public StartupActionAddObject newAction { get; set; }

		public StartupActionAddMessage(StartupActionAddObject newAction)
		{
			this.newAction = newAction;
		}

		public StartupActionAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			newAction.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			newAction = new StartupActionAddObject();
			newAction.Deserialize(reader);
		}

	}
}
