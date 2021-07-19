namespace AmaknaProxy.API.Protocol.Messages
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class GameActionFightTriggerEffectMessage : GameActionFightDispellEffectMessage
	{
		public new const uint Id = 8207;
		public override uint MessageId => Id;

		public GameActionFightTriggerEffectMessage(ushort actionId, double sourceId, double targetId, bool verboseCast, int boostUID)
		{
			this.actionId = actionId;
			this.sourceId = sourceId;
			this.targetId = targetId;
			this.verboseCast = verboseCast;
			this.boostUID = boostUID;
		}

		public GameActionFightTriggerEffectMessage() { }

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
