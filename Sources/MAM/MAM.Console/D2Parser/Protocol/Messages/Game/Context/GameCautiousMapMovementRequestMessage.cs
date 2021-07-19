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
	public class GameCautiousMapMovementRequestMessage : GameMapMovementRequestMessage
	{
		public new const uint Id = 5698;
		public override uint MessageId => Id;

		public GameCautiousMapMovementRequestMessage(IEnumerable<short> keyMovements, double mapId)
		{
			this.keyMovements = keyMovements;
			this.mapId = mapId;
		}

		public GameCautiousMapMovementRequestMessage() { }

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
