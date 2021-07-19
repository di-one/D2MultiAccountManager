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
	public class ExchangeStartOkJobIndexMessage : NetworkMessage
	{
		public const uint Id = 4353;
		public override uint MessageId => Id;
		public IEnumerable<uint> jobs { get; set; }

		public ExchangeStartOkJobIndexMessage(IEnumerable<uint> jobs)
		{
			this.jobs = jobs;
		}

		public ExchangeStartOkJobIndexMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)jobs.Count());
			foreach (var objectToSend in jobs)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var jobsCount = reader.ReadUShort();
			var jobs_ = new uint[jobsCount];
			for (var jobsIndex = 0; jobsIndex < jobsCount; jobsIndex++)
			{
				jobs_[jobsIndex] = reader.ReadVarUInt();
			}
			jobs = jobs_;
		}

	}
}
