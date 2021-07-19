namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuestModeMessage : NetworkMessage
	{
		public const uint Id = 6388;
		public override uint MessageId => Id;
		public bool active { get; set; }

		public GuestModeMessage(bool active)
		{
			this.active = active;
		}

		public GuestModeMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(active);
		}

		public override void Deserialize(IDataReader reader)
		{
			active = reader.ReadBoolean();
		}

	}
}
