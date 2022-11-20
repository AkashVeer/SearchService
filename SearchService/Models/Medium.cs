using System.Text.Json.Serialization;

namespace SearchService.Models
{
    public class Medium : Entity
    {
        [JsonIgnore] public int TypeWeight = 3;
        [JsonIgnore] public int OwnerWeight = 10;
        [JsonIgnore] public int SerialNumberWeight = 8;
        [JsonIgnore] public int DescriptionWeight = 6;

        public string GroupId { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public Medium() { }

        public Medium(Medium obj)
        {
            Id = obj.Id;
            Weight = obj.Weight;
            Type = obj.Type;
            Owner = obj.Owner;
            SerialNumber = obj.SerialNumber;
            Description = obj.Description;
        }

    }
}
