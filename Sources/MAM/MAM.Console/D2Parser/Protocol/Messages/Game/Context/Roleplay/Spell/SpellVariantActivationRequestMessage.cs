namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpellVariantActivationRequestMessage : NetworkMessage
	{
		public const uint Id = 2539;
		public override uint MessageId => Id;
		public ushort spellId { get; set; }

		public SpellVariantActivationRequestMessage(ushort spellId)
		{
			this.spellId = spellId;
		}

		public SpellVariantActivationRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(spellId);
		}

		public override void Deserialize(IDataReader reader)
		{
			spellId = reader.ReadVarUShort();
		}

	}
}
