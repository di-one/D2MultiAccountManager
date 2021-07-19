namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachRewardBuyMessage : NetworkMessage
	{
		public const uint Id = 273;
		public override uint MessageId => Id;
		public uint objectId { get; set; }

		public BreachRewardBuyMessage(uint objectId)
		{
			this.objectId = objectId;
		}

		public BreachRewardBuyMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectId);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUInt();
		}

	}
}
