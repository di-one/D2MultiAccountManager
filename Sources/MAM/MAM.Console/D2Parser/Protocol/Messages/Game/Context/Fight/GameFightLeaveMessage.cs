namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightLeaveMessage : NetworkMessage
	{
		public const uint Id = 2140;
		public override uint MessageId => Id;
		public double charId { get; set; }

		public GameFightLeaveMessage(double charId)
		{
			this.charId = charId;
		}

		public GameFightLeaveMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(charId);
		}

		public override void Deserialize(IDataReader reader)
		{
			charId = reader.ReadDouble();
		}

	}
}
