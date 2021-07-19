namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GuildPaddockRemovedMessage : NetworkMessage
	{
		public const uint Id = 2520;
		public override uint MessageId => Id;
		public double paddockId { get; set; }

		public GuildPaddockRemovedMessage(double paddockId)
		{
			this.paddockId = paddockId;
		}

		public GuildPaddockRemovedMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(paddockId);
		}

		public override void Deserialize(IDataReader reader)
		{
			paddockId = reader.ReadDouble();
		}

	}
}
