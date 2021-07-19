namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachCharactersMessage : NetworkMessage
	{
		public const uint Id = 9618;
		public override uint MessageId => Id;
		public IEnumerable<ulong> characters { get; set; }

		public BreachCharactersMessage(IEnumerable<ulong> characters)
		{
			this.characters = characters;
		}

		public BreachCharactersMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)characters.Count());
			foreach (var objectToSend in characters)
            {
				writer.WriteVarULong(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var charactersCount = reader.ReadUShort();
			var characters_ = new ulong[charactersCount];
			for (var charactersIndex = 0; charactersIndex < charactersCount; charactersIndex++)
			{
				characters_[charactersIndex] = reader.ReadVarULong();
			}
			characters = characters_;
		}

	}
}
