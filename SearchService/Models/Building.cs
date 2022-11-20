using System.Text.Json.Serialization;

namespace SearchServiceLSM.Models
{
    public class Building : Entity
    {
        [JsonIgnore] public int ShortCutWeight = 7;
        [JsonIgnore] public int ShortCutTWeight = 8;
        [JsonIgnore] public int NameWeight = 10;
        [JsonIgnore] public int NameTWeight = 5;
        [JsonIgnore] public int DescriptionWeight = 5;
        [JsonIgnore] public int DescriptionTWeight = 0;

        public string ShortCut { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<string> Locks { get; set; }

        public Building()
        {
            Locks = new List<string>();
        }

        public Building(Building building)
        {
            Id = building.Id;
            Weight = building.Weight;
            ShortCut = building.ShortCut;
            Name = building.Name;
            Description = building.Description;
            Locks = building.Locks;
        }

    }
}
