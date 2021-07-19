namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class LifePointsRegenBeginMessage : NetworkMessage
	{
		public const uint Id = 8582;
		public override uint MessageId => Id;
		public byte regenRate { get; set; }

		public LifePointsRegenBeginMessage(byte regenRate)
		{
			this.regenRate = regenRate;
		}

		public LifePointsRegenBeginMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteByte(regenRate);
		}

		public override void Deserialize(IDataReader reader)
		{
			regenRate = reader.ReadByte();
		}

	}
}
