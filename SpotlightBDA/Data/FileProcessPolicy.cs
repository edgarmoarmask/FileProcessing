namespace SpotlightBDA.Data
{
    public class FileProcessPolicy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CheckLimitPolicy>? CheckLimitPolicies { get; set; }
        public ICollection<ReplacePolicy>? ReplacePolicies { get; set; }
    }
}
