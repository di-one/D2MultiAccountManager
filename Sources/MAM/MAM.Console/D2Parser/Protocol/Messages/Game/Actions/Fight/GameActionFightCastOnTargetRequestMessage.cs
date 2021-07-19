namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightCastOnTargetRequestMessage : NetworkMessage
	{
		public const uint Id = 3262;
		public override uint MessageId => Id;
		public ushort spellId { get; set; }
		public double targetId { get; set; }

		public GameActionFightCastOnTargetRequestMessage(ushort spellId, double targetId)
		{
			this.spellId = spellId;
			this.targetId = targetId;
		}

		public GameActionFightCastOnTargetRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(spellId);
			writer.WriteDouble(targetId);
		}

		public override void Deserialize(IDataReader reader)
		{
			spellId = reader.ReadVarUShort();
			targetId = reader.ReadDouble();
		}

	}
}
