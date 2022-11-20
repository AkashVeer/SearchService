﻿using System.Text.Json.Serialization;

namespace SearchService.Models
{
    public class Lock : Entity
    {
        [JsonIgnore] public int TypeWeight = 3;
        [JsonIgnore] public int NameWeight = 10;
        [JsonIgnore] public int SerialNumberWeight = 8;
        [JsonIgnore] public int FloorWeight = 6;
        [JsonIgnore] public int RoomNumberWeight = 6;
        [JsonIgnore] public int DescriptionWeight = 6;

        public string BuildingId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
        public string Description { get; set; }

        public Lock() { }

        public Lock(Lock obj)
        {
            Id = obj.Id;
            Weight = obj.Weight;
            BuildingId = obj.BuildingId;
            Type = obj.Type;
            Name = obj.Name;
            SerialNumber = obj.SerialNumber;
            Floor = obj.Floor;
            RoomNumber = obj.RoomNumber;
            Description = obj.Description;
        }

    }
}
