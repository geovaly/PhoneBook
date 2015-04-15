using System;
using InterviewTest.Domain.Model.PhoneBook;

namespace InterviewTest.Persistance.Sequences
{
    public class IncrementalContactIdSequence : IGenerateSequenceId<ContactId>
    {
        private readonly IEntitySerializer<ContactIdSequence> _idSequenceSerializer;
        private readonly Lazy<ContactIdSequence> _lazyIdSequence;

        public IncrementalContactIdSequence(
            IEntitySerializer<ContactIdSequence> idSequenceSerializer)
        {
            _idSequenceSerializer = idSequenceSerializer;
            _lazyIdSequence = new Lazy<ContactIdSequence>(DeserializeIdSequence);
        }

        public ContactId GenerateNextId()
        {
            IdSequence.CurrentId = new ContactId(IdSequence.CurrentId.Value + 1);
            _idSequenceSerializer.Serialize(IdSequence);
            return IdSequence.CurrentId;
        }

        private ContactIdSequence IdSequence
        {
            get { return _lazyIdSequence.Value; }
        }

        private ContactIdSequence DeserializeIdSequence()
        {
            return _idSequenceSerializer.WasSerialized
                ? _idSequenceSerializer.Deserialize()
                : new ContactIdSequence();
        }
    }
}
