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
	public class AcquaintancesListMessage : NetworkMessage
	{
		public const uint Id = 4437;
		public override uint MessageId => Id;
		public IEnumerable<AcquaintanceInformation> acquaintanceList { get; set; }

		public AcquaintancesListMessage(IEnumerable<AcquaintanceInformation> acquaintanceList)
		{
			this.acquaintanceList = acquaintanceList;
		}

		public AcquaintancesListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)acquaintanceList.Count());
			foreach (var objectToSend in acquaintanceList)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var acquaintanceListCount = reader.ReadUShort();
			var acquaintanceList_ = new AcquaintanceInformation[acquaintanceListCount];
			for (var acquaintanceListIndex = 0; acquaintanceListIndex < acquaintanceListCount; acquaintanceListIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<AcquaintanceInformation>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				acquaintanceList_[acquaintanceListIndex] = objectToAdd;
			}
			acquaintanceList = acquaintanceList_;
		}

	}
}
