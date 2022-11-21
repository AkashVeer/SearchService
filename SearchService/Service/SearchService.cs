using Newtonsoft.Json;
using SearchServiceLSM.Models;
using System.Runtime.CompilerServices;

namespace SearchServiceLSM.Service
{
    public class SearchService : ISearchService
    {
        // Can be added as configuration in AppSettings and use IOptions pattern to inject here.
        private readonly string _filepath = @".\Data\sv_lsm_data.json";

        private DataFile? _dataFile;

        // Dictionary will help to access data using Ids
        private readonly Dictionary<string, Entity> _dict;

        public SearchService()
        {
            _dict = new Dictionary<string, Entity>();

            // We do it here to avoid reading file every time search is requested
            GetDataFromJsonFile();

            // Setup dictionary
            InitDictionary();
        }

        /// <summary>
        /// Search text between the entities
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public async Task<string> Search(string text)
        {
            if (_dataFile is null)
                return String.Empty;

            var result = new List<Entity>();

            foreach (var buildingItem in _dataFile.buildings)
            {
                buildingItem.CalculateWeight(text, _dict);

                if (buildingItem.Weight > 0)
                {
                    var newBuildingItem = new Building(buildingItem);
                    result.Add(newBuildingItem);
                    buildingItem.Weight = 0;
                }
            }

            foreach (var lockItem in _dataFile.locks)
            {
                lockItem.CalculateWeight(text);

                if (lockItem.Weight > 0)
                {
                    var newLockItem = new Lock(lockItem);
                    result.Add(newLockItem);
                    lockItem.Weight = 0;
                }
            }

            foreach (var groupItem in _dataFile.groups)
            {
                groupItem.CalculateWeight(text, _dict);

                if (groupItem.Weight > 0)
                {
                    var newGroupItem = new Group(groupItem);
                    result.Add(newGroupItem);
                    groupItem.Weight = 0;
                }
            }

            foreach (var mediumItem in _dataFile.media)
            {
                mediumItem.CalculateWeight(text);

                if (mediumItem.Weight > 0)
                {
                    var newMediumItem = new Medium(mediumItem);
                    result.Add(newMediumItem);
                    mediumItem.Weight = 0;
                }
            }

            // Sort by weight descending
            result = result.OrderByDescending(r => r.Weight).ToList();

            return await Task.Run(() => JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// Gets data from "sv_lsm_data.json"
        /// </summary>
        /// <returns></returns>
        private void GetDataFromJsonFile()
        {
            // Read file and deserialize from json
            var content = File.ReadAllText(_filepath);
            _dataFile = JsonConvert.DeserializeObject<DataFile>(content);
        }

        /// <summary>
        /// Add entities to dictionary
        /// </summary>
        private void InitDictionary()
        {
            if (_dataFile is null)
                return;

            foreach (var buildingItem in _dataFile.buildings)
            {
                _dict.Add(buildingItem.Id, buildingItem);
            }

            foreach (var lockItem in _dataFile.locks)
            {
                _dict.Add(lockItem.Id, lockItem);

                // Match Locks to Buildings
                if (!string.IsNullOrEmpty(lockItem.BuildingId) && _dict.ContainsKey(lockItem.BuildingId))
                {
                    ((Building)_dict[lockItem.BuildingId]).Locks.Add(lockItem.Id);
                }
            }

            foreach (var groupItem in _dataFile.groups)
            {
                _dict.Add(groupItem.Id, groupItem);
            }

            foreach (var mediumItem in _dataFile.media)
            {
                _dict.Add(mediumItem.Id, mediumItem);

                // Match Mediums to Groups
                if (!string.IsNullOrEmpty(mediumItem.GroupId) && _dict.ContainsKey(mediumItem.GroupId))
                {
                    ((Group)_dict[mediumItem.GroupId]).Media.Add(mediumItem.Id);
                }
            }
        }
    }
}
