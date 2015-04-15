namespace InterviewTest.Persistance
{
    public interface IGenerateSequenceId<out TId>
    {
        TId GenerateNextId();
    }
}
