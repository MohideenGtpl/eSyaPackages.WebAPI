using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HCP.Packages.DO;
using HCP.Packages.DO.StaticVariables;
using HCP.Packages.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HCP.Packages.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PackageMasterController : ControllerBase
    {
        private readonly IPackageMasterRepository _iPackageMasterRepository;
        private readonly ICommonMethodRepository _iCommonMethodRepository;

        public PackageMasterController(IPackageMasterRepository iPackageMasterRepository, ICommonMethodRepository iCommonMethodRepository)
        {
            _iPackageMasterRepository = iPackageMasterRepository;
            _iCommonMethodRepository = iCommonMethodRepository;
        }


        /// <summary>
        /// Get Business Locations
        /// UI Reffered - Package Master
        /// </summary>
        public async Task<IActionResult> GetBusinessKey()
        {
            var msg = await _iCommonMethodRepository.GetBusinessKey();
            return Ok(msg);
        }


        /// <summary>
        /// Get Patient Types
        /// UI Reffered - Package Master
        /// </summary>
        public async Task<IActionResult> GetPatientTypes()
        {
            var msg = await _iCommonMethodRepository.GetApplicationCodeByCodeType(CodeTypeValues.PatientType);
            return Ok(msg);
        }


        /// <summary>
        /// Get Currency Codes
        /// UI Reffered - Package Master
        /// </summary>
        public async Task<IActionResult> GetCurrencyCodes()
        {
            var msg = await _iCommonMethodRepository.GetCurrencyCodes();
            return Ok(msg);
        }

        /// <summary>
        /// Get Customers
        /// UI Reffered - Package Master
        /// </summary>
        public async Task<IActionResult> GetCustomers()
        {
            var msg = await _iCommonMethodRepository.GetCustomers();
            return Ok(msg);
        }

        /// <summary>
        /// Get Packages
        /// UI Reffered - Package Master
        /// </summary>
        public async Task<IActionResult> GetPackages()
        {
            var msg = await _iCommonMethodRepository.GetApplicationCodeByCodeType(CodeTypeValues.Packages);
            return Ok(msg);
        }

        /// <summary>
        /// Get Package Master
        /// UI Reffered - Package Master
        /// </summary>
       
        public async Task<IActionResult> GetPackageMaster(int businessKey, int customerId, string currencyCode)
        {
            var msg = await _iPackageMasterRepository.GetPackageMaster(businessKey,customerId,currencyCode);
            return Ok(msg);
        }

        /// <summary>
        /// Get Package Master
        /// UI Reffered - Package Master
        /// </summary>

        public async Task<IActionResult> GetPackageServices(int businessKey, string currencyCode)
        {
            var msg = await _iCommonMethodRepository.GetPackageServices(businessKey,currencyCode,RateTypeValues.HospitalRate);
            return Ok(msg);
        }

        /// <summary>
        /// Add Or Update Package Master
        /// UI Reffered - Package Master
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddOrUpdatePackageMaster(DO_PackageMaster obj)
        {
            var msg = await _iPackageMasterRepository.AddOrUpdatePackageMaster(obj);
            return Ok(msg);

        }
    }
}