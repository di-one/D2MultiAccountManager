namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class ForgettableSpellClientActionMessage : NetworkMessage
	{
		public const uint Id = 9656;
		public override uint MessageId => Id;
		public int spellId { get; set; }
		public sbyte action { get; set; }

		public ForgettableSpellClientActionMessage(int spellId, sbyte action)
		{
			this.spellId = spellId;
			this.action = action;
		}

		public ForgettableSpellClientActionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteInt(spellId);
			writer.WriteSByte(action);
		}

		public override void Deserialize(IDataReader reader)
		{
			spellId = reader.ReadInt();
			action = reader.ReadSByte();
		}

	}
}
