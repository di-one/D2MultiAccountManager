namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismInfoJoinLeaveRequestMessage : NetworkMessage
	{
		public const uint Id = 8778;
		public override uint MessageId => Id;
		public bool join { get; set; }

		public PrismInfoJoinLeaveRequestMessage(bool join)
		{
			this.join = join;
		}

		public PrismInfoJoinLeaveRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(join);
		}

		public override void Deserialize(IDataReader reader)
		{
			join = reader.ReadBoolean();
		}

	}
}
