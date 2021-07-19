namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachRewardBoughtMessage : NetworkMessage
	{
		public const uint Id = 7086;
		public override uint MessageId => Id;
		public uint objectId { get; set; }
		public bool bought { get; set; }

		public BreachRewardBoughtMessage(uint objectId, bool bought)
		{
			this.objectId = objectId;
			this.bought = bought;
		}

		public BreachRewardBoughtMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectId);
			writer.WriteBoolean(bought);
		}

		public override void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUInt();
			bought = reader.ReadBoolean();
		}

	}
}
