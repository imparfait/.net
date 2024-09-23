namespace writerBio.Models
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Life { get; set; }
        public List<string> Works { get; set; }
        public List<string> Awards { get; set; } 
        public List<string> Facts { get; set; }
    }
}
