namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameFightSpellCooldown
	{
		public const short Id  = 7464;
		public virtual short TypeId => Id;
		public int spellId { get; set; }
		public sbyte cooldown { get; set; }

		public GameFightSpellCooldown(int spellId, sbyte cooldown)
		{
			this.spellId = spellId;
			this.cooldown = cooldown;
		}

		public GameFightSpellCooldown() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(spellId);
			writer.WriteSByte(cooldown);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			spellId = reader.ReadInt();
			cooldown = reader.ReadSByte();
		}

	}
}
