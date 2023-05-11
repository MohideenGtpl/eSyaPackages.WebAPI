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
    public class PackageMasterRepository : IPackageMasterRepository
    {
        private eSyaEnterprise _context { get; set; }

        public PackageMasterRepository(eSyaEnterprise context)
        {
            _context = context;
        }

        public async Task<List<DO_PackageMaster>> GetPackageMaster(int businessKey, int customerId, string currencyCode)
        {
            try
            {
                var ds = await _context.GtPkphhd.Where(x => x.ActiveStatus == true && x.BusinessKey == businessKey && x.CustomerId == customerId && x.CurrencyCode == currencyCode).Select(
                      p => new DO_PackageMaster
                      {
                          PackageId = p.PackageId,
                          PackageCode = p.PackageCode,
                          PackageShortCode = _context.GtEcapcd.Where(a => a.ApplicationCode == p.PackageCode).FirstOrDefault().ShortCode,
                          PackageDesc = _context.GtEcapcd.Where(a => a.ApplicationCode == p.PackageCode).FirstOrDefault().CodeDesc,
                          PackageAmount = p.PackageAmount,
                          ActualCost = p.ActualCost,
                          EffectiveDate = p.EffectiveDate,
                          EffectiveTill = p.EffectiveTill,
                          ActiveStatus = p.ActiveStatus
                      }).ToListAsync();

                return ds;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DO_ReturnParameter> AddOrUpdatePackageMaster(DO_PackageMaster obj)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (obj.PackageId == 0)
                    {
                        var newPackageId = _context.GtPkphhd.Select(a => (int)a.PackageId).DefaultIfEmpty(0).Max() + 1;

                        var package_h = new GtPkphhd
                        {
                            BusinessKey = obj.BusinessKey,
                            PackageId = newPackageId,
                            PackageCode = obj.PackageCode,
                            CustomerId = obj.CustomerId,
                            CurrencyCode = obj.CurrencyCode,
                            EffectiveDate = obj.EffectiveDate,
                            ActualCost = obj.ActualCost,
                            PackageAmount = obj.PackageAmount,
                            ServiceChargePercentage = obj.ServiceChargePercentage,
                            EffectiveTill = obj.EffectiveTill,
                            PatientCopy = obj.PatientCopy,
                            FoodProvided = obj.FoodProvided,
                            ActiveStatus = obj.ActiveStatus,

                            FormId = obj.FormId,
                            CreatedBy = obj.UserID,
                            CreatedOn = System.DateTime.Now,
                            CreatedTerminal = obj.TerminalID
                        };
                        _context.GtPkphhd.Add(package_h);

                        foreach (var s in obj.l_services)
                        {
                            GtPkphdt ser = new GtPkphdt
                            {
                                BusinessKey = obj.BusinessKey,
                                PackageId = obj.PackageId,
                                ServiceType = s.ServiceType,
                                ServiceId = s.ServiceId,
                                Quantity = s.Quantity,
                                ActualPrice = s.ActualPrice,
                                ServiceRate = s.ServiceRate,

                                ActiveStatus = obj.ActiveStatus,
                                FormId = obj.FormId,
                                CreatedBy = obj.UserID,
                                CreatedOn = System.DateTime.Now,
                                CreatedTerminal = obj.TerminalID
                            };
                            _context.GtPkphdt.Add(ser);
                        }
                    }
                    await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();

                    return new DO_ReturnParameter() { Status = true, Message = "Saved Successfully." };
                }
                catch (DbUpdateException ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }

            }
        }
    }
}
