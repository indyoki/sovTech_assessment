using ChuckSwapi.Brokers.Interfaces;
using ChuckSwapi.Components.Interfaces;
using ChuckSwapi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapi.Components
{
    public class SWLogic : ISWLogic
    {
        private readonly ISWBroker _swBroker;
        public SWLogic(ISWBroker swBroker)
        {
            _swBroker = swBroker;
        }
        public async Task<List<Person>> GetAllEntries()
        {
            return await _swBroker.GetAllPeople();
        }
        public Task<Person> Search(string query)
        {
            return _swBroker.Search(query);
        }
    }
}
