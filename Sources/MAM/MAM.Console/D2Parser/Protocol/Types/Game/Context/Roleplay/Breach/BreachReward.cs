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
	public class BreachReward
	{
		public const short Id  = 4284;
		public virtual short TypeId => Id;
		public uint objectId { get; set; }
		public IEnumerable<byte> buyLocks { get; set; }
		public string buyCriterion { get; set; }
		public int remainingQty { get; set; }
		public uint price { get; set; }

		public BreachReward(uint objectId, IEnumerable<byte> buyLocks, string buyCriterion, int remainingQty, uint price)
		{
			this.objectId = objectId;
			this.buyLocks = buyLocks;
			this.buyCriterion = buyCriterion;
			this.remainingQty = remainingQty;
			this.price = price;
		}

		public BreachReward() { }

		public virtual void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(objectId);
			writer.WriteShort((short)buyLocks.Count());
			foreach (var objectToSend in buyLocks)
            {
				writer.WriteByte(objectToSend);
			}
			writer.WriteUTF(buyCriterion);
			writer.WriteVarInt(remainingQty);
			writer.WriteVarUInt(price);
		}

		public virtual void Deserialize(IDataReader reader)
		{
			objectId = reader.ReadVarUInt();
			var buyLocksCount = reader.ReadUShort();
			var buyLocks_ = new byte[buyLocksCount];
			for (var buyLocksIndex = 0; buyLocksIndex < buyLocksCount; buyLocksIndex++)
			{
				buyLocks_[buyLocksIndex] = reader.ReadByte();
			}
			buyLocks = buyLocks_;
			buyCriterion = reader.ReadUTF();
			remainingQty = reader.ReadVarInt();
			price = reader.ReadVarUInt();
		}

	}
}
