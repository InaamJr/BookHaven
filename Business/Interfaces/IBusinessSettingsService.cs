using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Business.Interfaces
{
    public interface IBusinessSettingsService
    {
        BusinessSettingsModel GetBusinessSettings();
        void UpdateBusinessSettings(BusinessSettingsModel settings);
    }
}
