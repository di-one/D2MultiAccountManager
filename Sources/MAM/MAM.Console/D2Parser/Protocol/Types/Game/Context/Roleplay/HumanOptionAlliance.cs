namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class HumanOptionAlliance : HumanOption
	{
		public new const short Id = 1332;
		public override short TypeId => Id;
		public AllianceInformations allianceInformations { get; set; }
		public sbyte aggressable { get; set; }

		public HumanOptionAlliance(AllianceInformations allianceInformations, sbyte aggressable)
		{
			this.allianceInformations = allianceInformations;
			this.aggressable = aggressable;
		}

		public HumanOptionAlliance() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			allianceInformations.Serialize(writer);
			writer.WriteSByte(aggressable);
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			allianceInformations = new AllianceInformations();
			allianceInformations.Deserialize(reader);
			aggressable = reader.ReadSByte();
		}

	}
}
