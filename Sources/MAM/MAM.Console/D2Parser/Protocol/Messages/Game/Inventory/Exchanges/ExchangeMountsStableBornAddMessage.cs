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
	public class ExchangeMountsStableBornAddMessage : ExchangeMountsStableAddMessage
	{
		public new const uint Id = 9611;
		public override uint MessageId => Id;

		public ExchangeMountsStableBornAddMessage(IEnumerable<MountClientData> mountDescription)
		{
			this.mountDescription = mountDescription;
		}

		public ExchangeMountsStableBornAddMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
		}

	}
}
