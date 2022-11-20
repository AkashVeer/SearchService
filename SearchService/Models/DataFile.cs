namespace SearchService.Models
{
    public class DataFile
    {
        public List<Building> buildings { get; set; }
        public List<Lock> locks { get; set; }
        public List<Group> groups { get; set; }
        public List<Medium> media { get; set; }
    }
}
