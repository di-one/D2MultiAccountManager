namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class MountSetXpRatioRequestMessage : NetworkMessage
	{
		public const uint Id = 9120;
		public override uint MessageId => Id;
		public sbyte xpRatio { get; set; }

		public MountSetXpRatioRequestMessage(sbyte xpRatio)
		{
			this.xpRatio = xpRatio;
		}

		public MountSetXpRatioRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(xpRatio);
		}

		public override void Deserialize(IDataReader reader)
		{
			xpRatio = reader.ReadSByte();
		}

	}
}
