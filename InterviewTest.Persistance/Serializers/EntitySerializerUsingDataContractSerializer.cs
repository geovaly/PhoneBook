using System;
using System.IO;
using System.Runtime.Serialization;

namespace InterviewTest.Persistance.Serializers
{
    public class EntitySerializerUsingDataContractSerializer<TEntity> : IEntitySerializer<TEntity>
    {
        private readonly string _fileName;


        public EntitySerializerUsingDataContractSerializer(string fileName)
        {
            _fileName = fileName;
        }

        public void Serialize(TEntity o)
        {
            using (var stream = new FileStream(_fileName, FileMode.Create))
            {
                new DataContractSerializer(typeof(TEntity)).WriteObject(stream, o);
            }
        }

        public TEntity Deserialize()
        {
            if (!WasSerialized)
                throw new InvalidOperationException();

            using (var stream = new FileStream(_fileName, FileMode.Open))
            {
                return (TEntity)new DataContractSerializer(typeof(TEntity)).ReadObject(stream);
            }
        }

        public bool WasSerialized
        {
            get { return File.Exists(_fileName); }
        }
    }
}
