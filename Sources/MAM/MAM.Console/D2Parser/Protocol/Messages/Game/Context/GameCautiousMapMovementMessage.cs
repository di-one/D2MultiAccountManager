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
	public class GameCautiousMapMovementMessage : GameMapMovementMessage
	{
		public new const uint Id = 1982;
		public override uint MessageId => Id;

		public GameCautiousMapMovementMessage(IEnumerable<short> keyMovements, short forcedDirection, double actorId)
		{
			this.keyMovements = keyMovements;
			this.forcedDirection = forcedDirection;
			this.actorId = actorId;
		}

		public GameCautiousMapMovementMessage() { }

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
