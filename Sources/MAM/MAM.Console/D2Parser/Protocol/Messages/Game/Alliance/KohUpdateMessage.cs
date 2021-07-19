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
	public class KohUpdateMessage : NetworkMessage
	{
		public const uint Id = 2532;
		public override uint MessageId => Id;
		public IEnumerable<AllianceInformations> alliances { get; set; }
		public IEnumerable<ushort> allianceNbMembers { get; set; }
		public IEnumerable<uint> allianceRoundWeigth { get; set; }
		public IEnumerable<byte> allianceMatchScore { get; set; }
		public IEnumerable<BasicAllianceInformations> allianceMapWinners { get; set; }
		public uint allianceMapWinnerScore { get; set; }
		public uint allianceMapMyAllianceScore { get; set; }
		public double nextTickTime { get; set; }

		public KohUpdateMessage(IEnumerable<AllianceInformations> alliances, IEnumerable<ushort> allianceNbMembers, IEnumerable<uint> allianceRoundWeigth, IEnumerable<byte> allianceMatchScore, IEnumerable<BasicAllianceInformations> allianceMapWinners, uint allianceMapWinnerScore, uint allianceMapMyAllianceScore, double nextTickTime)
		{
			this.alliances = alliances;
			this.allianceNbMembers = allianceNbMembers;
			this.allianceRoundWeigth = allianceRoundWeigth;
			this.allianceMatchScore = allianceMatchScore;
			this.allianceMapWinners = allianceMapWinners;
			this.allianceMapWinnerScore = allianceMapWinnerScore;
			this.allianceMapMyAllianceScore = allianceMapMyAllianceScore;
			this.nextTickTime = nextTickTime;
		}

		public KohUpdateMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteShort((short)alliances.Count());
			foreach (var objectToSend in alliances)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteShort((short)allianceNbMembers.Count());
			foreach (var objectToSend in allianceNbMembers)
            {
				writer.WriteVarUShort(objectToSend);
			}
			writer.WriteShort((short)allianceRoundWeigth.Count());
			foreach (var objectToSend in allianceRoundWeigth)
            {
				writer.WriteVarUInt(objectToSend);
			}
			writer.WriteShort((short)allianceMatchScore.Count());
			foreach (var objectToSend in allianceMatchScore)
            {
				writer.WriteByte(objectToSend);
			}
			writer.WriteShort((short)allianceMapWinners.Count());
			foreach (var objectToSend in allianceMapWinners)
            {
				objectToSend.Serialize(writer);
			}
			writer.WriteVarUInt(allianceMapWinnerScore);
			writer.WriteVarUInt(allianceMapMyAllianceScore);
			writer.WriteDouble(nextTickTime);
		}

		public override void Deserialize(IDataReader reader)
		{
			var alliancesCount = reader.ReadUShort();
			var alliances_ = new AllianceInformations[alliancesCount];
			for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
			{
				var objectToAdd = new AllianceInformations();
				objectToAdd.Deserialize(reader);
				alliances_[alliancesIndex] = objectToAdd;
			}
			alliances = alliances_;
			var allianceNbMembersCount = reader.ReadUShort();
			var allianceNbMembers_ = new ushort[allianceNbMembersCount];
			for (var allianceNbMembersIndex = 0; allianceNbMembersIndex < allianceNbMembersCount; allianceNbMembersIndex++)
			{
				allianceNbMembers_[allianceNbMembersIndex] = reader.ReadVarUShort();
			}
			allianceNbMembers = allianceNbMembers_;
			var allianceRoundWeigthCount = reader.ReadUShort();
			var allianceRoundWeigth_ = new uint[allianceRoundWeigthCount];
			for (var allianceRoundWeigthIndex = 0; allianceRoundWeigthIndex < allianceRoundWeigthCount; allianceRoundWeigthIndex++)
			{
				allianceRoundWeigth_[allianceRoundWeigthIndex] = reader.ReadVarUInt();
			}
			allianceRoundWeigth = allianceRoundWeigth_;
			var allianceMatchScoreCount = reader.ReadUShort();
			var allianceMatchScore_ = new byte[allianceMatchScoreCount];
			for (var allianceMatchScoreIndex = 0; allianceMatchScoreIndex < allianceMatchScoreCount; allianceMatchScoreIndex++)
			{
				allianceMatchScore_[allianceMatchScoreIndex] = reader.ReadByte();
			}
			allianceMatchScore = allianceMatchScore_;
			var allianceMapWinnersCount = reader.ReadUShort();
			var allianceMapWinners_ = new BasicAllianceInformations[allianceMapWinnersCount];
			for (var allianceMapWinnersIndex = 0; allianceMapWinnersIndex < allianceMapWinnersCount; allianceMapWinnersIndex++)
			{
				var objectToAdd = new BasicAllianceInformations();
				objectToAdd.Deserialize(reader);
				allianceMapWinners_[allianceMapWinnersIndex] = objectToAdd;
			}
			allianceMapWinners = allianceMapWinners_;
			allianceMapWinnerScore = reader.ReadVarUInt();
			allianceMapMyAllianceScore = reader.ReadVarUInt();
			nextTickTime = reader.ReadDouble();
		}

	}
}
