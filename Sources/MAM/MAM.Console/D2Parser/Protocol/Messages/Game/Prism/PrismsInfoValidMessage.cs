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
	public class PrismsInfoValidMessage : NetworkMessage
	{
		public const uint Id = 5320;
		public override uint MessageId => Id;
		public IEnumerable<PrismFightersInformation> fights { get; set; }

		public PrismsInfoValidMessage(IEnumerable<PrismFightersInformation> fights)
		{
			this.fights = fights;
		}

		public PrismsInfoValidMessage() { }

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
			var fights_ = new PrismFightersInformation[fightsCount];
			for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
			{
				var objectToAdd = new PrismFightersInformation();
				objectToAdd.Deserialize(reader);
				fights_[fightsIndex] = objectToAdd;
			}
			fights = fights_;
		}

	}
}
