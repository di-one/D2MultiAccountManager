namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class DungeonPartyFinderAvailableDungeonsRequestMessage : NetworkMessage
	{
		public const uint Id = 3938;
		public override uint MessageId => Id;

		public DungeonPartyFinderAvailableDungeonsRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
		}

		public override void Deserialize(IDataReader reader)
		{
		}

	}
}
