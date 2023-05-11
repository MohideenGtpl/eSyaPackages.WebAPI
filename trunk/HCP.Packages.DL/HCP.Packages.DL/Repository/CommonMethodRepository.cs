using HCP.Packages.DL.Entities;
using HCP.Packages.DO;
using HCP.Packages.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCP.Packages.DL.Repository
{
    public class CommonMethodRepository : ICommonMethodRepository
    {
        private eSyaEnterprise _context { get; set; }

        public CommonMethodRepository(eSyaEnterprise context)
        {
            _context = context;
        }


        public async Task<List<DO_ApplicationCode>> GetApplicationCodeByCodeType(int codeType)
        {
            var ac = _context.GtEcapcd
               .Where(w => w.CodeType == codeType && w.ActiveStatus)
               .Select(s => new DO_ApplicationCode
               {
                   ApplicationCode = s.ApplicationCode,
                   CodeDesc = s.CodeDesc
               })
               .ToListAsync();
            return await ac;
        }

        public async Task<List<DO_BusinessLocation>> GetBusinessKey()
        {
            try
            {
                    var bk = _context.GtEcbsln
                        .Where(w => w.ActiveStatus)
                        .Select(r => new DO_BusinessLocation
                        {
                            BusinessKey = r.BusinessKey,
                            LocationDescription = r.BusinessName + " - " + r.LocationDescription
                        }).ToListAsync();

                    return await bk;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_CurrencyCode>> GetCurrencyCodes()
        {
            try
            {
                    var cc = _context.GtEccuco
                        .Where(w => w.ActiveStatus)
                        .Select(c => new DO_CurrencyCode
                        {
                            CurrencyCode = c.CurrencyCode,
                            CurrencyName = c.CurrencyName
                        }).ToListAsync();

                    return await cc;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_Customer>> GetCustomers()
        {
            try
            {
                var c = _context.GtEacscc
                    .Where(w => w.ActiveStatus)
                    .Select(x => new DO_Customer
                    {
                        CustomerId = x.CustomerId,
                        CustomerName = x.CustomerName
                    }).ToListAsync();

                return await c;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DO_PackageService>> GetPackageServices(int businessKey, string currencyCode, int rateType)
        {
            try
            {
                var _ser = _context.GtEssrbr
                    .Join(_context.GtEssrms,
                    r => r.ServiceId,
                    s => s.ServiceId,
                    (r,s) => new { r,s})
                    .Join(_context.GtEssrcl,
                    rs => rs.s.ServiceClassId,
                    c => c.ServiceClassId,
                    (rs, c) => new { rs, c })
                    .Join(_context.GtEssrgr,
                    rsc => rsc.c.ServiceGroupId,
                    g => g.ServiceGroupId,
                    (rsc, g) => new { rsc, g })
                    .Where(w =>  w.rsc.rs.r.BusinessKey==businessKey && w.rsc.rs.r.CurrencyCode==currencyCode  && w.rsc.rs.r.RateType== rateType && w.rsc.rs.r.ActiveStatus)
                    .Select(x => new DO_PackageService
                    {
                        ServiceType = x.g.ServiceTypeId,
                        ServiceId = x.rsc.rs.r.ServiceId,
                        ServiceDesc=x.rsc.rs.s.ServiceDesc,
                        ServiceRate=x.rsc.rs.r.OpbaseRate
                    }).ToListAsync();

                return await _ser;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
