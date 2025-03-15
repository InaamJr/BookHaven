using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Business.Interfaces;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Business.Services
{
    public class BusinessSettingsService : IBusinessSettingsService
    {
        private readonly IBusinessSettingsRepository _settingsRepository;

        public BusinessSettingsService(IBusinessSettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public BusinessSettingsModel GetBusinessSettings() => _settingsRepository.GetBusinessSettings();

        public void UpdateBusinessSettings(BusinessSettingsModel settings) => _settingsRepository.UpdateBusinessSettings(settings);
    }
}
