namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayPlayerLifeStatusMessage : NetworkMessage
	{
		public const uint Id = 7932;
		public override uint MessageId => Id;
		public sbyte state { get; set; }
		public double phenixMapId { get; set; }

		public GameRolePlayPlayerLifeStatusMessage(sbyte state, double phenixMapId)
		{
			this.state = state;
			this.phenixMapId = phenixMapId;
		}

		public GameRolePlayPlayerLifeStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(state);
			writer.WriteDouble(phenixMapId);
		}

		public override void Deserialize(IDataReader reader)
		{
			state = reader.ReadSByte();
			phenixMapId = reader.ReadDouble();
		}

	}
}
