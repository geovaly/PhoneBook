using System;

namespace InterviewTest.Persistance
{
    public interface IEntitySerializer<T>
    {
        void Serialize(T entity);

        bool WasSerialized { get; }

        T Deserialize();
    }
}
