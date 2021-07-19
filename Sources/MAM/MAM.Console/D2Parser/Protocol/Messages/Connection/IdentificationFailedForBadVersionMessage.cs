namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;
	using Version = AmaknaProxy.API.Protocol.Types.Version;

	[Serializable]
	public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
	{
		public new const uint Id = 8989;
		public override uint MessageId => Id;
		public Version requiredVersion { get; set; }

		public IdentificationFailedForBadVersionMessage(sbyte reason, Version requiredVersion)
		{
			this.reason = reason;
			this.requiredVersion = requiredVersion;
		}

		public IdentificationFailedForBadVersionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			requiredVersion.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			requiredVersion = new Version();
			requiredVersion.Deserialize(reader);
		}

	}
}
