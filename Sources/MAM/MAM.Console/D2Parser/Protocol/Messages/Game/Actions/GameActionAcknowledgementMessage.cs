namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionAcknowledgementMessage : NetworkMessage
	{
		public const uint Id = 3999;
		public override uint MessageId => Id;
		public bool valid { get; set; }
		public sbyte actionId { get; set; }

		public GameActionAcknowledgementMessage(bool valid, sbyte actionId)
		{
			this.valid = valid;
			this.actionId = actionId;
		}

		public GameActionAcknowledgementMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(valid);
			writer.WriteSByte(actionId);
		}

		public override void Deserialize(IDataReader reader)
		{
			valid = reader.ReadBoolean();
			actionId = reader.ReadSByte();
		}

	}
}
