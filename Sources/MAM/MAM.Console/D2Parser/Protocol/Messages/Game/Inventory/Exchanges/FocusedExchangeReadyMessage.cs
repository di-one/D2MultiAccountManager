namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class FocusedExchangeReadyMessage : ExchangeReadyMessage
	{
		public new const uint Id = 8151;
		public override uint MessageId => Id;
		public uint focusActionId { get; set; }

		public FocusedExchangeReadyMessage(bool ready, ushort step, uint focusActionId)
		{
			this.ready = ready;
			this.step = step;
			this.focusActionId = focusActionId;
		}

		public FocusedExchangeReadyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarUInt(focusActionId);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			focusActionId = reader.ReadVarUInt();
		}

	}
}
