namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class TaxCollectorWaitingForHelpInformations : TaxCollectorComplementaryInformations
	{
		public new const short Id = 9165;
		public override short TypeId => Id;
		public ProtectedEntityWaitingForHelpInfo waitingForHelpInfo { get; set; }

		public TaxCollectorWaitingForHelpInformations(ProtectedEntityWaitingForHelpInfo waitingForHelpInfo)
		{
			this.waitingForHelpInfo = waitingForHelpInfo;
		}

		public TaxCollectorWaitingForHelpInformations() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			waitingForHelpInfo.Serialize(writer);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			waitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
			waitingForHelpInfo.Deserialize(reader);
		}

	}
}
