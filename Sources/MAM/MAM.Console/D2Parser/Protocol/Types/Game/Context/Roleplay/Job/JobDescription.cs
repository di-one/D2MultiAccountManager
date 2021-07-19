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
	public class JobDescription
	{
		public const short Id  = 5999;
		public virtual short TypeId => Id;
		public sbyte jobId { get; set; }
		public IEnumerable<SkillActionDescription> skills { get; set; }

		public JobDescription(sbyte jobId, IEnumerable<SkillActionDescription> skills)
		{
			this.jobId = jobId;
			this.skills = skills;
		}

		public JobDescription() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(jobId);
			writer.WriteShort((short)skills.Count());
			foreach (var objectToSend in skills)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			jobId = reader.ReadSByte();
			var skillsCount = reader.ReadUShort();
			var skills_ = new SkillActionDescription[skillsCount];
			for (var skillsIndex = 0; skillsIndex < skillsCount; skillsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<SkillActionDescription>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				skills_[skillsIndex] = objectToAdd;
			}
			skills = skills_;
		}

	}
}
