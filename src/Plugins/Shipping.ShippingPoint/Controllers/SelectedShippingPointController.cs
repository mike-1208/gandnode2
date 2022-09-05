﻿using Grand.Business.Core.Interfaces.Catalog.Prices;
using Grand.Business.Core.Interfaces.Common.Directory;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shipping.ShippingPoint.Models;
using Shipping.ShippingPoint.Services;

namespace Shipping.ShippingPoint.Controllers
{
    public class SelectedShippingPointController : Controller
    {
        private readonly IShippingPointService _shippingPointService;
        private readonly ICountryService _countryService;
        private readonly IPriceFormatter _priceFormatter;
        private readonly IWorkContext _workContext;
        private readonly ICurrencyService _currencyService;
        private readonly ITranslationService _translationService;

        public SelectedShippingPointController(
            IShippingPointService shippingPointService,
            ICountryService countryService,
            IPriceFormatter priceFormatter,
            IWorkContext workContext,
            ICurrencyService currencyService,
            ITranslationService translationService)
        {
            _shippingPointService = shippingPointService;
            _countryService = countryService;
            _priceFormatter = priceFormatter;
            _workContext = workContext;
            _currencyService = currencyService;
            _translationService = translationService;
        }
        public async Task<IActionResult> Get(string shippingOptionId)
        {
            var shippingPoint = await _shippingPointService.GetStoreShippingPointById(shippingOptionId);
            if (shippingPoint != null)
            {
                double rateBase = await _currencyService.ConvertFromPrimaryStoreCurrency(shippingPoint.PickupFee, _workContext.WorkingCurrency);
                var fee = _priceFormatter.FormatShippingPrice(rateBase);

                var viewModel = new PointModel() {
                    ShippingPointName = shippingPoint.ShippingPointName,
                    Description = shippingPoint.Description,
                    PickupFee = fee,
                    OpeningHours = shippingPoint.OpeningHours,
                    Address1 = shippingPoint.Address1,
                    City = shippingPoint.City,
                    CountryName = (await _countryService.GetCountryById(shippingPoint.CountryId))?.Name,
                    ZipPostalCode = shippingPoint.ZipPostalCode,
                };
                return View(viewModel);
            }
            return Content("ShippingPointController: given Shipping Option doesn't exist");
        }

        public async Task<IActionResult> Points(string shippingOption)
        {
            var parameter = shippingOption.Split(new[] { "___" }, StringSplitOptions.RemoveEmptyEntries)[0];

            if (parameter == _translationService.GetResource("Shipping.ShippingPoint.PluginName"))
            {
                var shippingPoints = await _shippingPointService.GetAllStoreShippingPoint(_workContext.CurrentStore.Id);

                var shippingPointsModel = new List<SelectListItem>();
                shippingPointsModel.Add(new SelectListItem() { Value = "", Text = _translationService.GetResource("Shipping.ShippingPoint.SelectShippingOption") });

                foreach (var shippingPoint in shippingPoints)
                {
                    shippingPointsModel.Add(new SelectListItem() { Value = shippingPoint.Id, Text = shippingPoint.ShippingPointName });
                }

                return View(shippingPointsModel);
            }
            return Content("ShippingPointController: given Shipping Option doesn't exist");

        }
    }
}
