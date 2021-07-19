namespace AmaknaProxy.API.Protocol.Types
{
	using System;
	using System.Linq;
	using System.Text;
	using AmaknaProxy.API.Protocol.Types;
	using System.Collections.Generic;
	using AmaknaProxy.API.Network;
	using AmaknaProxy.API.IO;

	[Serializable]
	public class PartyIdol : Idol
	{
		public new const short Id = 1785;
		public override short TypeId => Id;
		public IEnumerable<ulong> ownersIds { get; set; }

		public PartyIdol(ushort objectId, ushort xpBonusPercent, ushort dropBonusPercent, IEnumerable<ulong> ownersIds)
		{
			this.objectId = objectId;
			this.xpBonusPercent = xpBonusPercent;
			this.dropBonusPercent = dropBonusPercent;
			this.ownersIds = ownersIds;
		}

		public PartyIdol() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)ownersIds.Count());
			foreach (var objectToSend in ownersIds)
            {
				writer.WriteVarULong(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var ownersIdsCount = reader.ReadUShort();
			var ownersIds_ = new ulong[ownersIdsCount];
			for (var ownersIdsIndex = 0; ownersIdsIndex < ownersIdsCount; ownersIdsIndex++)
			{
				ownersIds_[ownersIdsIndex] = reader.ReadVarULong();
			}
			ownersIds = ownersIds_;
		}

	}
}
