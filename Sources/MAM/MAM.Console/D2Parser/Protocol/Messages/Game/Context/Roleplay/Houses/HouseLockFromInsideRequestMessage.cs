namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
	{
		public new const uint Id = 3332;
		public override uint MessageId => Id;

		public HouseLockFromInsideRequestMessage(string code)
		{
			this.code = code;
		}

		public HouseLockFromInsideRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
