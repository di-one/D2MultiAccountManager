namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class BreachBranch
	{
		public const short Id  = 9905;
		public virtual short TypeId => Id;
		public sbyte room { get; set; }
		public int element { get; set; }
		public IEnumerable<MonsterInGroupLightInformations> bosses { get; set; }
		public double map { get; set; }
		public short score { get; set; }
		public short relativeScore { get; set; }
		public IEnumerable<MonsterInGroupLightInformations> monsters { get; set; }

		public BreachBranch(sbyte room, int element, IEnumerable<MonsterInGroupLightInformations> bosses, double map, short score, short relativeScore, IEnumerable<MonsterInGroupLightInformations> monsters)
		{
			this.room = room;
			this.element = element;
			this.bosses = bosses;
			this.map = map;
			this.score = score;
			this.relativeScore = relativeScore;
			this.monsters = monsters;
		}

		public BreachBranch() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(room);
			writer.WriteInt(element);
			writer.WriteShort((short)bosses.Count());
			foreach (var objectToSend in bosses)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteDouble(map);
			writer.WriteShort(score);
			writer.WriteShort(relativeScore);
			writer.WriteShort((short)monsters.Count());
			foreach (var objectToSend in monsters)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			room = reader.ReadSByte();
			element = reader.ReadInt();
			var bossesCount = reader.ReadUShort();
			var bosses_ = new MonsterInGroupLightInformations[bossesCount];
			for (var bossesIndex = 0; bossesIndex < bossesCount; bossesIndex++)
			{
				var objectToAdd = new MonsterInGroupLightInformations();
				objectToAdd.Deserialize(reader);
				bosses_[bossesIndex] = objectToAdd;
			}
			bosses = bosses_;
			map = reader.ReadDouble();
			score = reader.ReadShort();
			relativeScore = reader.ReadShort();
			var monstersCount = reader.ReadUShort();
			var monsters_ = new MonsterInGroupLightInformations[monstersCount];
			for (var monstersIndex = 0; monstersIndex < monstersCount; monstersIndex++)
			{
				var objectToAdd = new MonsterInGroupLightInformations();
				objectToAdd.Deserialize(reader);
				monsters_[monstersIndex] = objectToAdd;
			}
			monsters = monsters_;
		}

	}
}
