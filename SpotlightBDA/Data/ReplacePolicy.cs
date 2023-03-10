namespace SpotlightBDA.Data
{
    public class ReplacePolicy
    {
        public int Id { get; set; }
        public SpecialCharacter Find { get; set; }
        public string Replace { get; set; }
        public bool Silent { get; set; } = false;
    }
}
