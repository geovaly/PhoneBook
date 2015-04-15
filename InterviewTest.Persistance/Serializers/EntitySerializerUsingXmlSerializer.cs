using System;
using System.IO;
using System.Xml.Serialization;

namespace InterviewTest.Persistance.Serializers
{
    public class EntitySerializerUsingXmlSerializer<TEntity, TDto> : IEntitySerializer<TEntity>
    {
        private readonly string _fileName;
        private readonly IDtoConverter<TEntity, TDto> _converter;
        private readonly XmlSerializer _serializer;


        public EntitySerializerUsingXmlSerializer(string fileName, IDtoConverter<TEntity, TDto> converter)
        {
            _fileName = fileName;
            _converter = converter;
            _serializer = new XmlSerializer(typeof(TDto));
        }

        public void Serialize(TEntity o)
        {
            using (TextWriter writer = new StreamWriter(_fileName))
            {
                _serializer.Serialize(writer, _converter.ToDto(o));
            }
        }

        public TEntity Deserialize()
        {
            if (!WasSerialized)
                throw new InvalidOperationException();

            using (TextReader reader = new StreamReader(_fileName))
            {
                return _converter.ToEntity((TDto)_serializer.Deserialize(reader));
            }
        }

        public bool WasSerialized
        {
            get { return File.Exists(_fileName); }
        }
    }
}
