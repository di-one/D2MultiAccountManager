namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class JobBookSubscription
	{
		public const short Id  = 4800;
		public virtual short TypeId => Id;
		public sbyte jobId { get; set; }
		public bool subscribed { get; set; }

		public JobBookSubscription(sbyte jobId, bool subscribed)
		{
			this.jobId = jobId;
			this.subscribed = subscribed;
		}

		public JobBookSubscription() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteSByte(jobId);
			writer.WriteBoolean(subscribed);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			jobId = reader.ReadSByte();
			subscribed = reader.ReadBoolean();
		}

	}
}
