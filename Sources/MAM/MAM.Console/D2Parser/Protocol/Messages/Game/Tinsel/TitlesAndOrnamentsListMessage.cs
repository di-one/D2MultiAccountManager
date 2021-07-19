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
	public class TitlesAndOrnamentsListMessage : NetworkMessage
	{
		public const uint Id = 928;
		public override uint MessageId => Id;
		public IEnumerable<ushort> titles { get; set; }
		public IEnumerable<ushort> ornaments { get; set; }
		public ushort activeTitle { get; set; }
		public ushort activeOrnament { get; set; }

		public TitlesAndOrnamentsListMessage(IEnumerable<ushort> titles, IEnumerable<ushort> ornaments, ushort activeTitle, ushort activeOrnament)
		{
			this.titles = titles;
			this.ornaments = ornaments;
			this.activeTitle = activeTitle;
			this.activeOrnament = activeOrnament;
		}

		public TitlesAndOrnamentsListMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)titles.Count());
			foreach (var objectToSend in titles)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)ornaments.Count());
			foreach (var objectToSend in ornaments)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteVarUShort(activeTitle);
			writer.WriteVarUShort(activeOrnament);
		}

		public override void Deserialize(IDataReader reader)
		{
			var titlesCount = reader.ReadUShort();
			var titles_ = new ushort[titlesCount];
			for (var titlesIndex = 0; titlesIndex < titlesCount; titlesIndex++)
			{
				titles_[titlesIndex] = reader.ReadVarUShort();
			}
			titles = titles_;
			var ornamentsCount = reader.ReadUShort();
			var ornaments_ = new ushort[ornamentsCount];
			for (var ornamentsIndex = 0; ornamentsIndex < ornamentsCount; ornamentsIndex++)
			{
				ornaments_[ornamentsIndex] = reader.ReadVarUShort();
			}
			ornaments = ornaments_;
			activeTitle = reader.ReadVarUShort();
			activeOrnament = reader.ReadVarUShort();
		}

	}
}
