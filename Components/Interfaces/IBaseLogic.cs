using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChuckSwapi.Components.Interfaces
{
    public interface IBaseLogic<T>
    {
        Task<List<T>> GetAllEntries();
        Task<T> Search(string query);
    }
}
