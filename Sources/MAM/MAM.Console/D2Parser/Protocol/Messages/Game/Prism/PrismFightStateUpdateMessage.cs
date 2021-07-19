namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismFightStateUpdateMessage : NetworkMessage
	{
		public const uint Id = 8529;
		public override uint MessageId => Id;
		public sbyte state { get; set; }

		public PrismFightStateUpdateMessage(sbyte state)
		{
			this.state = state;
		}

		public PrismFightStateUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(state);
		}

		public override void Deserialize(IDataReader reader)
		{
			state = reader.ReadSByte();
		}

	}
}
