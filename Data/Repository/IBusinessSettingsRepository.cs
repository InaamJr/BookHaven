using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface IBusinessSettingsRepository
    {
        BusinessSettingsModel GetBusinessSettings();
        void UpdateBusinessSettings(BusinessSettingsModel settings);
    }
}
