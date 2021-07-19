namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class AchievementAlmostFinishedDetailedListRequestMessage : NetworkMessage
	{
		public const uint Id = 5179;
		public override uint MessageId => Id;

		public AchievementAlmostFinishedDetailedListRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
		}

		public override void Deserialize(IDataReader reader)
		{
		}

	}
}
