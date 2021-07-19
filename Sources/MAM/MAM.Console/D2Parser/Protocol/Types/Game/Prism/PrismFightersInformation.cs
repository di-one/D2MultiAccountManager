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
	public class PrismFightersInformation
	{
		public const short Id  = 4877;
		public virtual short TypeId => Id;
		public ushort subAreaId { get; set; }
		public ProtectedEntityWaitingForHelpInfo waitingForHelpInfo { get; set; }
		public IEnumerable<CharacterMinimalPlusLookInformations> allyCharactersInformations { get; set; }
		public IEnumerable<CharacterMinimalPlusLookInformations> enemyCharactersInformations { get; set; }

		public PrismFightersInformation(ushort subAreaId, ProtectedEntityWaitingForHelpInfo waitingForHelpInfo, IEnumerable<CharacterMinimalPlusLookInformations> allyCharactersInformations, IEnumerable<CharacterMinimalPlusLookInformations> enemyCharactersInformations)
		{
			this.subAreaId = subAreaId;
			this.waitingForHelpInfo = waitingForHelpInfo;
			this.allyCharactersInformations = allyCharactersInformations;
			this.enemyCharactersInformations = enemyCharactersInformations;
		}

		public PrismFightersInformation() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(subAreaId);
			waitingForHelpInfo.Serialize(writer);
			writer.WriteShort((short)allyCharactersInformations.Count());
			foreach (var objectToSend in allyCharactersInformations)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)enemyCharactersInformations.Count());
			foreach (var objectToSend in enemyCharactersInformations)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			subAreaId = reader.ReadVarUShort();
			waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
			waitingForHelpInfo.Deserialize(reader);
			var allyCharactersInformationsCount = reader.ReadUShort();
			var allyCharactersInformations_ = new CharacterMinimalPlusLookInformations[allyCharactersInformationsCount];
			for (var allyCharactersInformationsIndex = 0; allyCharactersInformationsIndex < allyCharactersInformationsCount; allyCharactersInformationsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				allyCharactersInformations_[allyCharactersInformationsIndex] = objectToAdd;
			}
			allyCharactersInformations = allyCharactersInformations_;
			var enemyCharactersInformationsCount = reader.ReadUShort();
			var enemyCharactersInformations_ = new CharacterMinimalPlusLookInformations[enemyCharactersInformationsCount];
			for (var enemyCharactersInformationsIndex = 0; enemyCharactersInformationsIndex < enemyCharactersInformationsCount; enemyCharactersInformationsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				enemyCharactersInformations_[enemyCharactersInformationsIndex] = objectToAdd;
			}
			enemyCharactersInformations = enemyCharactersInformations_;
		}

	}
}
