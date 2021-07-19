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
	public class GroupMonsterStaticInformations
	{
		public const short Id  = 954;
		public virtual short TypeId => Id;
		public MonsterInGroupLightInformations mainCreatureLightInfos { get; set; }
		public IEnumerable<MonsterInGroupInformations> underlings { get; set; }

		public GroupMonsterStaticInformations(MonsterInGroupLightInformations mainCreatureLightInfos, IEnumerable<MonsterInGroupInformations> underlings)
		{
			this.mainCreatureLightInfos = mainCreatureLightInfos;
			this.underlings = underlings;
		}

		public GroupMonsterStaticInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			mainCreatureLightInfos.Serialize(writer);
			writer.WriteShort((short)underlings.Count());
			foreach (var objectToSend in underlings)
            {
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			mainCreatureLightInfos = new MonsterInGroupLightInformations();
			mainCreatureLightInfos.Deserialize(reader);
			var underlingsCount = reader.ReadUShort();
			var underlings_ = new MonsterInGroupInformations[underlingsCount];
			for (var underlingsIndex = 0; underlingsIndex < underlingsCount; underlingsIndex++)
			{
				var objectToAdd = new MonsterInGroupInformations();
				objectToAdd.Deserialize(reader);
				underlings_[underlingsIndex] = objectToAdd;
			}
			underlings = underlings_;
		}

	}
}
