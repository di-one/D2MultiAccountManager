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
	public class BreachInvitationRequestMessage : NetworkMessage
	{
		public const uint Id = 9368;
		public override uint MessageId => Id;
		public IEnumerable<ulong> guests { get; set; }

		public BreachInvitationRequestMessage(IEnumerable<ulong> guests)
		{
			this.guests = guests;
		}

		public BreachInvitationRequestMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)guests.Count());
			foreach (var objectToSend in guests)
            {
				writer.WriteVarULong(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var guestsCount = reader.ReadUShort();
			var guests_ = new ulong[guestsCount];
			for (var guestsIndex = 0; guestsIndex < guestsCount; guestsIndex++)
			{
				guests_[guestsIndex] = reader.ReadVarULong();
			}
			guests = guests_;
		}

	}
}
