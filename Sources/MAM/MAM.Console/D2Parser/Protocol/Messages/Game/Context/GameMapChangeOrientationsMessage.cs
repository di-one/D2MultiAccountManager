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
	public class GameMapChangeOrientationsMessage : NetworkMessage
	{
		public const uint Id = 9267;
		public override uint MessageId => Id;
		public IEnumerable<ActorOrientation> orientations { get; set; }

		public GameMapChangeOrientationsMessage(IEnumerable<ActorOrientation> orientations)
		{
			this.orientations = orientations;
		}

		public GameMapChangeOrientationsMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)orientations.Count());
			foreach (var objectToSend in orientations)
            {
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			var orientationsCount = reader.ReadUShort();
			var orientations_ = new ActorOrientation[orientationsCount];
			for (var orientationsIndex = 0; orientationsIndex < orientationsCount; orientationsIndex++)
			{
				var objectToAdd = new ActorOrientation();
				objectToAdd.Deserialize(reader);
				orientations_[orientationsIndex] = objectToAdd;
			}
			orientations = orientations_;
		}

	}
}
