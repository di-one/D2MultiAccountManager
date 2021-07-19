namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HavenBagDailyLoteryMessage : NetworkMessage
	{
		public const uint Id = 6985;
		public override uint MessageId => Id;
		public sbyte returnType { get; set; }
		public string gameActionId { get; set; }

		public HavenBagDailyLoteryMessage(sbyte returnType, string gameActionId)
		{
			this.returnType = returnType;
			this.gameActionId = gameActionId;
		}

		public HavenBagDailyLoteryMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(returnType);
			writer.WriteUTF(gameActionId);
		}

		public override void Deserialize(IDataReader reader)
		{
			returnType = reader.ReadSByte();
			gameActionId = reader.ReadUTF();
		}

	}
}
