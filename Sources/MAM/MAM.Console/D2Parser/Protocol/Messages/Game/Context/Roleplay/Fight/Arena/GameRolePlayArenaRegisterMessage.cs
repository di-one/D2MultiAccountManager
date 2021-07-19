namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameRolePlayArenaRegisterMessage : NetworkMessage
	{
		public const uint Id = 1295;
		public override uint MessageId => Id;
		public int battleMode { get; set; }

		public GameRolePlayArenaRegisterMessage(int battleMode)
		{
			this.battleMode = battleMode;
		}

		public GameRolePlayArenaRegisterMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(battleMode);
		}

		public override void Deserialize(IDataReader reader)
		{
			battleMode = reader.ReadInt();
		}

	}
}
