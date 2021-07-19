namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ClientYouAreDrunkMessage : DebugInClientMessage
	{
		public new const uint Id = 3068;
		public override uint MessageId => Id;

		public ClientYouAreDrunkMessage(sbyte level, string message)
		{
			this.level = level;
			this.message = message;
		}

		public ClientYouAreDrunkMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
