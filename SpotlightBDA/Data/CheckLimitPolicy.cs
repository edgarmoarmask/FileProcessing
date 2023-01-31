namespace SpotlightBDA.Data
{
    public class CheckLimitPolicy
    {
        public int Id { get; set; }
        public string StartString { get; set; }
        public string? EndString { get; set; }
        public string? Find { get; set; }
        public int Limit { get; set; }
    }
}
