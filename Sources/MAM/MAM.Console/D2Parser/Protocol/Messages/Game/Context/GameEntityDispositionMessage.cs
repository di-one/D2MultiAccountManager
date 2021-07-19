namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameEntityDispositionMessage : NetworkMessage
	{
		public const uint Id = 5064;
		public override uint MessageId => Id;
		public IdentifiedEntityDispositionInformations disposition { get; set; }

		public GameEntityDispositionMessage(IdentifiedEntityDispositionInformations disposition)
		{
			this.disposition = disposition;
		}

		public GameEntityDispositionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			disposition.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			disposition = new IdentifiedEntityDispositionInformations();
			disposition.Deserialize(reader);
		}

	}
}
