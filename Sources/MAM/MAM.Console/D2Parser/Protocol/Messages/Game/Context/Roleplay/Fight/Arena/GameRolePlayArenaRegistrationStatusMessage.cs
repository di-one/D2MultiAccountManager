namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayArenaRegistrationStatusMessage : NetworkMessage
	{
		public const uint Id = 1923;
		public override uint MessageId => Id;
		public bool registered { get; set; }
		public sbyte step { get; set; }
		public int battleMode { get; set; }

		public GameRolePlayArenaRegistrationStatusMessage(bool registered, sbyte step, int battleMode)
		{
			this.registered = registered;
			this.step = step;
			this.battleMode = battleMode;
		}

		public GameRolePlayArenaRegistrationStatusMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteBoolean(registered);
			writer.WriteSByte(step);
			writer.WriteInt(battleMode);
		}

		public override void Deserialize(IDataReader reader)
		{
			registered = reader.ReadBoolean();
			step = reader.ReadSByte();
			battleMode = reader.ReadInt();
		}

	}
}
