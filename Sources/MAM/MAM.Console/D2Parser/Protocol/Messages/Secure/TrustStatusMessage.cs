namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TrustStatusMessage : NetworkMessage
	{
		public const uint Id = 2797;
		public override uint MessageId => Id;
		public bool trusted { get; set; }
		public bool certified { get; set; }

		public TrustStatusMessage(bool trusted, bool certified)
		{
			this.trusted = trusted;
			this.certified = certified;
		}

		public TrustStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(flag, 0, trusted);
			flag = BooleanByteWrapper.SetFlag(flag, 1, certified);
			writer.WriteByte(flag);
		}

		public override void Deserialize(IDataReader reader)
		{
			var flag = reader.ReadByte();
			trusted = BooleanByteWrapper.GetFlag(flag, 0);
			certified = BooleanByteWrapper.GetFlag(flag, 1);
		}

	}
}
