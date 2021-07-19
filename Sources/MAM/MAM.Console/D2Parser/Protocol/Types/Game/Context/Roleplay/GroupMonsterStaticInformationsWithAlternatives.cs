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
	public class GroupMonsterStaticInformationsWithAlternatives : GroupMonsterStaticInformations
	{
		public new const short Id = 822;
		public override short TypeId => Id;
		public IEnumerable<AlternativeMonstersInGroupLightInformations> alternatives { get; set; }

		public GroupMonsterStaticInformationsWithAlternatives(MonsterInGroupLightInformations mainCreatureLightInfos, IEnumerable<MonsterInGroupInformations> underlings, IEnumerable<AlternativeMonstersInGroupLightInformations> alternatives)
		{
			this.mainCreatureLightInfos = mainCreatureLightInfos;
			this.underlings = underlings;
			this.alternatives = alternatives;
		}

		public GroupMonsterStaticInformationsWithAlternatives() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)alternatives.Count());
			foreach (var objectToSend in alternatives)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var alternativesCount = reader.ReadUShort();
			var alternatives_ = new AlternativeMonstersInGroupLightInformations[alternativesCount];
			for (var alternativesIndex = 0; alternativesIndex < alternativesCount; alternativesIndex++)
			{
				var objectToAdd = new AlternativeMonstersInGroupLightInformations();
				objectToAdd.Deserialize(reader);
				alternatives_[alternativesIndex] = objectToAdd;
			}
			alternatives = alternatives_;
		}

	}
}
