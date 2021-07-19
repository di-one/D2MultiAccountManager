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
	public class NpcDialogQuestionMessage : NetworkMessage
	{
		public const uint Id = 4062;
		public override uint MessageId => Id;
		public uint @messageId { get; set; }
		public IEnumerable<string> dialogParams { get; set; }
		public IEnumerable<uint> visibleReplies { get; set; }

		public NpcDialogQuestionMessage(uint @messageId, IEnumerable<string> dialogParams, IEnumerable<uint> visibleReplies)
		{
			this.@messageId = @messageId;
			this.dialogParams = dialogParams;
			this.visibleReplies = visibleReplies;
		}

		public NpcDialogQuestionMessage() { }

		public override void Serialize(IDataWriter writer)
		{
			writer.WriteVarUInt(@messageId);
			writer.WriteShort((short)dialogParams.Count());
			foreach (var objectToSend in dialogParams)
            {
				writer.WriteUTF(objectToSend);
			}
			writer.WriteShort((short)visibleReplies.Count());
			foreach (var objectToSend in visibleReplies)
            {
				writer.WriteVarUInt(objectToSend);
			}
		}

		public override void Deserialize(IDataReader reader)
		{
			@messageId = reader.ReadVarUInt();
			var dialogParamsCount = reader.ReadUShort();
			var dialogParams_ = new string[dialogParamsCount];
			for (var dialogParamsIndex = 0; dialogParamsIndex < dialogParamsCount; dialogParamsIndex++)
			{
				dialogParams_[dialogParamsIndex] = reader.ReadUTF();
			}
			dialogParams = dialogParams_;
			var visibleRepliesCount = reader.ReadUShort();
			var visibleReplies_ = new uint[visibleRepliesCount];
			for (var visibleRepliesIndex = 0; visibleRepliesIndex < visibleRepliesCount; visibleRepliesIndex++)
			{
				visibleReplies_[visibleRepliesIndex] = reader.ReadVarUInt();
			}
			visibleReplies = visibleReplies_;
		}

	}
}
