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
	public class AllianceInsiderInfoMessage : NetworkMessage
	{
		public const uint Id = 8455;
		public override uint MessageId => Id;
		public AllianceFactSheetInformations allianceInfos { get; set; }
		public IEnumerable<GuildInsiderFactSheetInformations> guilds { get; set; }
		public IEnumerable<PrismSubareaEmptyInfo> prisms { get; set; }

		public AllianceInsiderInfoMessage(AllianceFactSheetInformations allianceInfos, IEnumerable<GuildInsiderFactSheetInformations> guilds, IEnumerable<PrismSubareaEmptyInfo> prisms)
		{
			this.allianceInfos = allianceInfos;
			this.guilds = guilds;
			this.prisms = prisms;
		}

		public AllianceInsiderInfoMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			allianceInfos.Serialize(writer);
			writer.WriteShort((short)guilds.Count());
			foreach (var objectToSend in guilds)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)prisms.Count());
			foreach (var objectToSend in prisms)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			allianceInfos = new AllianceFactSheetInformations();
			allianceInfos.Deserialize(reader);
			var guildsCount = reader.ReadUShort();
			var guilds_ = new GuildInsiderFactSheetInformations[guildsCount];
			for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
			{
				var objectToAdd = new GuildInsiderFactSheetInformations();
				objectToAdd.Deserialize(reader);
				guilds_[guildsIndex] = objectToAdd;
			}
			guilds = guilds_;
			var prismsCount = reader.ReadUShort();
			var prisms_ = new PrismSubareaEmptyInfo[prismsCount];
			for (var prismsIndex = 0; prismsIndex < prismsCount; prismsIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>(reader.ReadShort());
				objectToAdd.Deserialize(reader);
				prisms_[prismsIndex] = objectToAdd;
			}
			prisms = prisms_;
		}

	}
}
