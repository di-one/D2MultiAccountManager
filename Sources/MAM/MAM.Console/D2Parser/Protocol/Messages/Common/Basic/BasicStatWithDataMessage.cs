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
	public class BasicStatWithDataMessage : BasicStatMessage
	{
		public new const uint Id = 1415;
		public override uint MessageId => Id;
		public IEnumerable<StatisticData> datas { get; set; }

		public BasicStatWithDataMessage(double timeSpent, ushort statId, IEnumerable<StatisticData> datas)
		{
			this.timeSpent = timeSpent;
			this.statId = statId;
			this.datas = datas;
		}

		public BasicStatWithDataMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			base.Serialize(writer);
			writer.WriteShort((short)datas.Count());
			foreach (var objectToSend in datas)
            {
				writer.WriteShort(objectToSend.TypeId);
				objectToSend.Serialize(writer);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			base.Deserialize(reader);
			var datasCount = reader.ReadUShort();
			var datas_ = new StatisticData[datasCount];
			for (var datasIndex = 0; datasIndex < datasCount; datasIndex++)
			{
				var objectToAdd = ProtocolTypeManager.GetInstance<StatisticData>((ushort)reader.ReadShort());
				objectToAdd.Deserialize(reader);
				datas_[datasIndex] = objectToAdd;
			}
			datas = datas_;
		}

	}
}
