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
	public class GuildInformationsPaddocksMessage : NetworkMessage
	{
		public const uint Id = 1363;
		public override uint MessageId => Id;
		public sbyte nbPaddockMax { get; set; }
		public IEnumerable<PaddockContentInformations> paddocksInformations { get; set; }

		public GuildInformationsPaddocksMessage(sbyte nbPaddockMax, IEnumerable<PaddockContentInformations> paddocksInformations)
		{
			this.nbPaddockMax = nbPaddockMax;
			this.paddocksInformations = paddocksInformations;
		}

		public GuildInformationsPaddocksMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(nbPaddockMax);
			writer.WriteShort((short)paddocksInformations.Count());
			foreach (var objectToSend in paddocksInformations)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			nbPaddockMax = reader.ReadSByte();
			var paddocksInformationsCount = reader.ReadUShort();
			var paddocksInformations_ = new PaddockContentInformations[paddocksInformationsCount];
			for (var paddocksInformationsIndex = 0; paddocksInformationsIndex < paddocksInformationsCount; paddocksInformationsIndex++)
			{
				var objectToAdd = new PaddockContentInformations();
				objectToAdd.Deserialize(reader);
				paddocksInformations_[paddocksInformationsIndex] = objectToAdd;
			}
			paddocksInformations = paddocksInformations_;
		}

	}
}
