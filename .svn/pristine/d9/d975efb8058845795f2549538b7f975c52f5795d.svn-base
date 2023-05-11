using HCP.Packages.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Packages.IF
{
    public interface IPackageMasterRepository
    {
        Task<List<DO_PackageMaster>> GetPackageMaster(int businessKey, int customerId, string currencyCode);
        Task<DO_ReturnParameter> AddOrUpdatePackageMaster(DO_PackageMaster obj);
    }
}
