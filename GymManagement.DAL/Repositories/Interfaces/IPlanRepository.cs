using GymManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagement.DAL.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        //Get All Plans
        Task<IEnumerable<Plan>> GetAllAsync(bool tracking = false,CancellationToken tk = default);

        //GetPlanById
        Task<Plan> GetByIdAsync(int id, CancellationToken tk = default);

        //Add
        Task<int> AddAsync(Plan plan, CancellationToken tk = default);

        //Update
        Task<int> UpdateAsync(Plan plan, CancellationToken tk = default);

        //Delete
        Task<int> DeleteAsync(Plan plan, CancellationToken tk = default);
    }
}
