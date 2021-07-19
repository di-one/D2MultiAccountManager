namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
	{
		public new const uint Id = 4163;
		public override uint MessageId => Id;
		public AbstractFightDispellableEffect effect { get; set; }

		public GameActionFightDispellableEffectMessage(ushort actionId, double sourceId, AbstractFightDispellableEffect effect)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.effect = effect;
		}

		public GameActionFightDispellableEffectMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort(effect.TypeId);
			effect.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			effect = ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>((ushort)reader.ReadShort());
			effect.Deserialize(reader);
		}

	}
}
