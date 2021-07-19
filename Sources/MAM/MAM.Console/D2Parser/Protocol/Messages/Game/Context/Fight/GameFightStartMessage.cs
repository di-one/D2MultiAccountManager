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
	public class GameFightStartMessage : NetworkMessage
	{
		public const uint Id = 9766;
		public override uint MessageId => Id;
		public IEnumerable<Idol> idols { get; set; }

		public GameFightStartMessage(IEnumerable<Idol> idols)
		{
			this.idols = idols;
		}

		public GameFightStartMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)idols.Count());
			foreach (var objectToSend in idols)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var idolsCount = reader.ReadUShort();
			var idols_ = new Idol[idolsCount];
			for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
			{
				var objectToAdd = new Idol();
				objectToAdd.Deserialize(reader);
				idols_[idolsIndex] = objectToAdd;
			}
			idols = idols_;
		}

	}
}
