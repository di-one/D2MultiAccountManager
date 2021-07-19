namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class SpellVariantActivationMessage : NetworkMessage
	{
		public const uint Id = 2077;
		public override uint MessageId => Id;
		public ushort spellId { get; set; }
		public bool result { get; set; }

		public SpellVariantActivationMessage(ushort spellId, bool result)
		{
			this.spellId = spellId;
			this.result = result;
		}

		public SpellVariantActivationMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUShort(spellId);
			writer.WriteBoolean(result);
		}

		public override void Deserialize(IDataReader reader)
		{
			spellId = reader.ReadVarUShort();
			result = reader.ReadBoolean();
		}

	}
}
