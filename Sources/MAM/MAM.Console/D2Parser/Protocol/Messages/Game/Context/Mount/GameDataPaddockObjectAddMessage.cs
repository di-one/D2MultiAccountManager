namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameDataPaddockObjectAddMessage : NetworkMessage
	{
		public const uint Id = 2589;
		public override uint MessageId => Id;
		public PaddockItem paddockItemDescription { get; set; }

		public GameDataPaddockObjectAddMessage(PaddockItem paddockItemDescription)
		{
			this.paddockItemDescription = paddockItemDescription;
		}

		public GameDataPaddockObjectAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			paddockItemDescription.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			paddockItemDescription = new PaddockItem();
			paddockItemDescription.Deserialize(reader);
		}

	}
}
