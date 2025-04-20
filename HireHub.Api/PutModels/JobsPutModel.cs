namespace HireHub.Api.PutModels
{
    public class JobsPutModel
    {
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string? Company { get; set; }
        public string JobRequirements { get; set; }
        public string JobSkills { get; set; }
        public string Area { get; set; }
        public int YearsOfExperienceRequired { get; set; }

    }
}
