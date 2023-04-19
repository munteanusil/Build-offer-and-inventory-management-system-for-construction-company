using CostControlApp.Models;

namespace CostControlApp.Contracts
{
    public interface IDenumireRepository
    {
        IEnumerable<Sheet1> Shearch(string SearchTerm);
    }
}
