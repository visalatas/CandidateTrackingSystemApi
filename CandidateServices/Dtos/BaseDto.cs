namespace CandidateCore.Dtos
{
    public class BaseDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
    public class BaseDto : BaseDto<int>
    {

    }
    
}
