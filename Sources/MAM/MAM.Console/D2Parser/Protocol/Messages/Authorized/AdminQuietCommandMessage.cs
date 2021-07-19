namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AdminQuietCommandMessage : AdminCommandMessage
	{
		public new const uint Id = 5788;
		public override uint MessageId => Id;

		public AdminQuietCommandMessage(string content)
		{
			this.content = content;
		}

		public AdminQuietCommandMessage() { }

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
