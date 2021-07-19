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
	public class AccountHouseMessage : NetworkMessage
	{
		public const uint Id = 2281;
		public override uint MessageId => Id;
		public IEnumerable<AccountHouseInformations> houses { get; set; }

		public AccountHouseMessage(IEnumerable<AccountHouseInformations> houses)
		{
			this.houses = houses;
		}

		public AccountHouseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)houses.Count());
			foreach (var objectToSend in houses)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var housesCount = reader.ReadUShort();
			var houses_ = new AccountHouseInformations[housesCount];
			for (var housesIndex = 0; housesIndex < housesCount; housesIndex++)
			{
				var objectToAdd = new AccountHouseInformations();
				objectToAdd.Deserialize(reader);
				houses_[housesIndex] = objectToAdd;
			}
			houses = houses_;
		}

	}
}
