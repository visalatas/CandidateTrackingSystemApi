namespace CandidateServices.Dtos
{
    public class PositionListDto
    {
        public string? SearchText { get; set; }
        public int? DepartmentId { get; set; }
        public int page { get; set; }
        public int DataCount { get; set; }
    }
}
