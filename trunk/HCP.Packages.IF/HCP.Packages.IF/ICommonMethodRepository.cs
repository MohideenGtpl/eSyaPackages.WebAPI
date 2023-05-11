using HCP.Packages.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Packages.IF
{
    public interface ICommonMethodRepository
    {
        Task<List<DO_ApplicationCode>> GetApplicationCodeByCodeType(int codeType);
        Task<List<DO_BusinessLocation>> GetBusinessKey();
        Task<List<DO_CurrencyCode>> GetCurrencyCodes();
        Task<List<DO_Customer>> GetCustomers();
        Task<List<DO_PackageService>> GetPackageServices(int businessKey, string currencyCode, int rateType);
    }
}
