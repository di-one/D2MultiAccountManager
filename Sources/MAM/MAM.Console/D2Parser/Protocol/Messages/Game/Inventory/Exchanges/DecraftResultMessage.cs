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
	public class DecraftResultMessage : NetworkMessage
	{
		public const uint Id = 8350;
		public override uint MessageId => Id;
		public IEnumerable<DecraftedItemStackInfo> results { get; set; }

		public DecraftResultMessage(IEnumerable<DecraftedItemStackInfo> results)
		{
			this.results = results;
		}

		public DecraftResultMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)results.Count());
			foreach (var objectToSend in results)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var resultsCount = reader.ReadUShort();
			var results_ = new DecraftedItemStackInfo[resultsCount];
			for (var resultsIndex = 0; resultsIndex < resultsCount; resultsIndex++)
			{
				var objectToAdd = new DecraftedItemStackInfo();
				objectToAdd.Deserialize(reader);
				results_[resultsIndex] = objectToAdd;
			}
			results = results_;
		}

	}
}
