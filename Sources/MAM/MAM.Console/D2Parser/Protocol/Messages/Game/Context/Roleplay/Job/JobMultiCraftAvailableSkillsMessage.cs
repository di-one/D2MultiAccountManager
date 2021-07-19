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
	public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
	{
		public new const uint Id = 3671;
		public override uint MessageId => Id;
		public ulong playerId { get; set; }
		public IEnumerable<ushort> skills { get; set; }

		public JobMultiCraftAvailableSkillsMessage(bool enabled, ulong playerId, IEnumerable<ushort> skills)
		{
			this.enabled = enabled;
			this.playerId = playerId;
			this.skills = skills;
		}

		public JobMultiCraftAvailableSkillsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteVarULong(playerId);
			writer.WriteShort((short)skills.Count());
			foreach (var objectToSend in skills)
            {
				writer.WriteVarUShort(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			playerId = reader.ReadVarULong();
			var skillsCount = reader.ReadUShort();
			var skills_ = new ushort[skillsCount];
			for (var skillsIndex = 0; skillsIndex < skillsCount; skillsIndex++)
			{
				skills_[skillsIndex] = reader.ReadVarUShort();
			}
			skills = skills_;
		}

	}
}
