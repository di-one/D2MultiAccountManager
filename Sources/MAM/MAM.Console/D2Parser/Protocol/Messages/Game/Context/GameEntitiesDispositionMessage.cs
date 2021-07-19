namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameEntitiesDispositionMessage : NetworkMessage
	{
		public const uint Id = 4495;
		public override uint MessageId => Id;
		public IEnumerable<IdentifiedEntityDispositionInformations> dispositions { get; set; }

		public GameEntitiesDispositionMessage(IEnumerable<IdentifiedEntityDispositionInformations> dispositions)
		{
			this.dispositions = dispositions;
		}

		public GameEntitiesDispositionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)dispositions.Count());
			foreach (var objectToSend in dispositions)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var dispositionsCount = reader.ReadUShort();
			var dispositions_ = new IdentifiedEntityDispositionInformations[dispositionsCount];
			for (var dispositionsIndex = 0; dispositionsIndex < dispositionsCount; dispositionsIndex++)
			{
				var objectToAdd = new IdentifiedEntityDispositionInformations();
				objectToAdd.Deserialize(reader);
				dispositions_[dispositionsIndex] = objectToAdd;
			}
			dispositions = dispositions_;
		}

	}
}
