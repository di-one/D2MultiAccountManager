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
	public class EntityMovementInformations
	{
		public const short Id  = 1828;
		public virtual short TypeId => Id;
		public int objectId { get; set; }
		public IEnumerable<sbyte> steps { get; set; }

		public EntityMovementInformations(int objectId, IEnumerable<sbyte> steps)
		{
			this.objectId = objectId;
			this.steps = steps;
		}

		public EntityMovementInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteInt(objectId);
			writer.WriteShort((short)steps.Count());
			foreach (var objectToSend in steps)
            {
				writer.WriteSByte(objectToSend);
			}
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadInt();
			var stepsCount = reader.ReadUShort();
			var steps_ = new sbyte[stepsCount];
			for (var stepsIndex = 0; stepsIndex < stepsCount; stepsIndex++)
			{
				steps_[stepsIndex] = reader.ReadSByte();
			}
			steps = steps_;
		}

	}
}
