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
	public class IdolFightPreparationUpdateMessage : NetworkMessage
	{
		public const uint Id = 8948;
		public override uint MessageId => Id;
		public sbyte idolSource { get; set; }
		public IEnumerable<Idol> idols { get; set; }

		public IdolFightPreparationUpdateMessage(sbyte idolSource, IEnumerable<Idol> idols)
		{
			this.idolSource = idolSource;
			this.idols = idols;
		}

		public IdolFightPreparationUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(idolSource);
			writer.WriteShort((short)idols.Count());
			foreach (var objectToSend in idols)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			idolSource = reader.ReadSByte();
			var idolsCount = reader.ReadUShort();
			var idols_ = new Idol[idolsCount];
			for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<Idol>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				idols_[idolsIndex] = objectToAdd;
			}
			idols = idols_;
		}

	}
}
