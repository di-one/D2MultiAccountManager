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
	public class HumanInformations
	{
		public const short Id  = 4572;
		public virtual short TypeId => Id;
		public ActorRestrictionsInformations restrictions { get; set; }
		public bool sex { get; set; }
		public IEnumerable<HumanOption> options { get; set; }

		public HumanInformations(ActorRestrictionsInformations restrictions, bool sex, IEnumerable<HumanOption> options)
		{
			this.restrictions = restrictions;
			this.sex = sex;
			this.options = options;
		}

		public HumanInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			restrictions.Serialize(writer);
			writer.WriteBoolean(sex);
			writer.WriteShort((short)options.Count());
			foreach (var objectToSend in options)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			restrictions = new ActorRestrictionsInformations();
			restrictions.Deserialize(reader);
			sex = reader.ReadBoolean();
			var optionsCount = reader.ReadUShort();
			var options_ = new HumanOption[optionsCount];
			for (var optionsIndex = 0; optionsIndex < optionsCount; optionsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				options_[optionsIndex] = objectToAdd;
			}
			options = options_;
		}

	}
}
