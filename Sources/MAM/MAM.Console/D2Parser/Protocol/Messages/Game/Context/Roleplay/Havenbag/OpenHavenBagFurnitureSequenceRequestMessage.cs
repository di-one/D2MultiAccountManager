﻿namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class OpenHavenBagFurnitureSequenceRequestMessage : NetworkMessage
	{
		public const uint Id = 868;
		public override uint MessageId => Id;

		public OpenHavenBagFurnitureSequenceRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
		}

		public override void Deserialize(IDataReader reader)
		{
		}

	}
}
