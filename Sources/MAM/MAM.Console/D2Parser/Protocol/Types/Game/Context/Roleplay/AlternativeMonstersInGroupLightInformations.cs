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
	public class AlternativeMonstersInGroupLightInformations
	{
		public const short Id  = 6668;
		public virtual short TypeId => Id;
		public int playerCount { get; set; }
		public IEnumerable<MonsterInGroupLightInformations> monsters { get; set; }

		public AlternativeMonstersInGroupLightInformations(int playerCount, IEnumerable<MonsterInGroupLightInformations> monsters)
		{
			this.playerCount = playerCount;
			this.monsters = monsters;
		}

		public AlternativeMonstersInGroupLightInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(playerCount);
			writer.WriteShort((short)monsters.Count());
			foreach (var objectToSend in monsters)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			playerCount = reader.ReadInt();
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
