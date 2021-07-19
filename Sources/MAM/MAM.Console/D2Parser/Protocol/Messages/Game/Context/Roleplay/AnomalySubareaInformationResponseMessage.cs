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
	public class AnomalySubareaInformationResponseMessage : NetworkMessage
	{
		public const uint Id = 1533;
		public override uint MessageId => Id;
		public IEnumerable<AnomalySubareaInformation> subareas { get; set; }

		public AnomalySubareaInformationResponseMessage(IEnumerable<AnomalySubareaInformation> subareas)
		{
			this.subareas = subareas;
		}

		public AnomalySubareaInformationResponseMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)subareas.Count());
			foreach (var objectToSend in subareas)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var subareasCount = reader.ReadUShort();
			var subareas_ = new AnomalySubareaInformation[subareasCount];
			for (var subareasIndex = 0; subareasIndex < subareasCount; subareasIndex++)
			{
				var objectToAdd = new AnomalySubareaInformation();
				objectToAdd.Deserialize(reader);
				subareas_[subareasIndex] = objectToAdd;
			}
			subareas = subareas_;
		}

	}
}
