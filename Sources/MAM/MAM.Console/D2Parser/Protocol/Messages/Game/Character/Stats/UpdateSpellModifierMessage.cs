namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class UpdateSpellModifierMessage : NetworkMessage
	{
		public const uint Id = 6108;
		public override uint MessageId => Id;
		public double actorId { get; set; }
		public CharacterSpellModification spellModifier { get; set; }

		public UpdateSpellModifierMessage(double actorId, CharacterSpellModification spellModifier)
		{
			this.actorId = actorId;
			this.spellModifier = spellModifier;
		}

		public UpdateSpellModifierMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(actorId);
			spellModifier.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			actorId = reader.ReadDouble();
			spellModifier = new CharacterSpellModification();
			spellModifier.Deserialize(reader);
		}

	}
}
