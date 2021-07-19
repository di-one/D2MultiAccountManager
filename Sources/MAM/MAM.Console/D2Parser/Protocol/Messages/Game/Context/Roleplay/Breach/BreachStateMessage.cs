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
	public class BreachStateMessage : NetworkMessage
	{
		public const uint Id = 4020;
		public override uint MessageId => Id;
		public CharacterMinimalInformations owner { get; set; }
		public IEnumerable<ObjectEffectInteger> bonuses { get; set; }
		public uint bugdet { get; set; }
		public bool saved { get; set; }

		public BreachStateMessage(CharacterMinimalInformations owner, IEnumerable<ObjectEffectInteger> bonuses, uint bugdet, bool saved)
		{
			this.owner = owner;
			this.bonuses = bonuses;
			this.bugdet = bugdet;
			this.saved = saved;
		}

		public BreachStateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			owner.Serialize(writer);
			writer.WriteShort((short)bonuses.Count());
			foreach (var objectToSend in bonuses)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteVarUInt(bugdet);
			writer.WriteBoolean(saved);
		}

		public override void Deserialize(IDataReader reader)
		{
			owner = new CharacterMinimalInformations();
			owner.Deserialize(reader);
			var bonusesCount = reader.ReadUShort();
			var bonuses_ = new ObjectEffectInteger[bonusesCount];
			for (var bonusesIndex = 0; bonusesIndex < bonusesCount; bonusesIndex++)
			{
				var objectToAdd = new ObjectEffectInteger();
				objectToAdd.Deserialize(reader);
				bonuses_[bonusesIndex] = objectToAdd;
			}
			bonuses = bonuses_;
			bugdet = reader.ReadVarUInt();
			saved = reader.ReadBoolean();
		}

	}
}
