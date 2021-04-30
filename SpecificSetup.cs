using Core.DTOs.Request;
using System.Collections.Generic;

namespace test.country
{
    public class CountrySetup : Setup<Entities.Country>
    {
        #region Country Properties

        public BreadCrumbFilterDto BreadcrumbFilterDtoTestData { get; private set; }

        #endregion Country Properties

        protected override void LoadTestData()
        {
            BreadcrumbFilterDtoTestData = new BreadCrumbFilterDto()
            {
                IsAllEngagement = false,
                FilterIds = new List<int>() { 1, 2, 3, 4 }
            };

            EntityTestData = new List<Entities.Country>();
        }
    }
}