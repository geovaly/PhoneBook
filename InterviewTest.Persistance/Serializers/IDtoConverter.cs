namespace InterviewTest.Persistance.Serializers
{
    public interface IDtoConverter<TEntity, TDto>
    {
        TEntity ToEntity(TDto dto);

        TDto ToDto(TEntity entity);
    }
}
