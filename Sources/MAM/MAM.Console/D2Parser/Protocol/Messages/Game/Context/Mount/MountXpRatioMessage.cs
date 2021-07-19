namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountXpRatioMessage : NetworkMessage
	{
		public const uint Id = 4059;
		public override uint MessageId => Id;
		public sbyte ratio { get; set; }

		public MountXpRatioMessage(sbyte ratio)
		{
			this.ratio = ratio;
		}

		public MountXpRatioMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(ratio);
		}

		public override void Deserialize(IDataReader reader)
		{
			ratio = reader.ReadSByte();
		}

	}
}
