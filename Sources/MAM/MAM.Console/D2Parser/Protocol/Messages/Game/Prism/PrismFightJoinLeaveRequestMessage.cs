namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PrismFightJoinLeaveRequestMessage : NetworkMessage
	{
		public const uint Id = 9973;
		public override uint MessageId => Id;
		public ushort subAreaId { get; set; }
		public bool join { get; set; }

		public PrismFightJoinLeaveRequestMessage(ushort subAreaId, bool join)
		{
			this.subAreaId = subAreaId;
			this.join = join;
		}

		public PrismFightJoinLeaveRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			writer.WriteBoolean(join);
		}

		public override void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			join = reader.ReadBoolean();
		}

	}
}
