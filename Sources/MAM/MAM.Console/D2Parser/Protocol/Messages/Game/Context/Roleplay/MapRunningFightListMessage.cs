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
	public class MapRunningFightListMessage : NetworkMessage
	{
		public const uint Id = 7526;
		public override uint MessageId => Id;
		public IEnumerable<FightExternalInformations> fights { get; set; }

		public MapRunningFightListMessage(IEnumerable<FightExternalInformations> fights)
		{
			this.fights = fights;
		}

		public MapRunningFightListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)fights.Count());
			foreach (var objectToSend in fights)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var fightsCount = reader.ReadUShort();
			var fights_ = new FightExternalInformations[fightsCount];
			for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
			{
				var objectToAdd = new FightExternalInformations();
				objectToAdd.Deserialize(reader);
				fights_[fightsIndex] = objectToAdd;
			}
			fights = fights_;
		}

	}
}
