namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameContextActorPositionInformations
	{
		public const short Id  = 8832;
		public virtual short TypeId => Id;
		public double contextualId { get; set; }
		public EntityDispositionInformations disposition { get; set; }

		public GameContextActorPositionInformations(double contextualId, EntityDispositionInformations disposition)
		{
			this.contextualId = contextualId;
			this.disposition = disposition;
		}

		public GameContextActorPositionInformations() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(contextualId);
			writer.WriteShort(disposition.TypeId);
			disposition.Serialize(writer);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			contextualId = reader.ReadDouble();
			disposition = ProtocolTypeManager.GetInstance<EntityDispositionInformations>(reader.ReadShort());
			disposition.Deserialize(reader);
		}

	}
}
