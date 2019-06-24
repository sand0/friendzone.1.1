using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private ICountryService _countryService;
        private ICityService _cityService;

        public LocationsController(
            ICountryService countrySrv,
            ICityService citySrv
            )
        {
            _countryService = countrySrv;
            _cityService = citySrv;
        }

        [HttpGet("[action]")]
        public IActionResult Countries()
        {
            return Ok(_countryService.GetCountries());
        }

        [HttpPost("countries/edit")]
        public async Task<IActionResult> EditCountry(Country country)
        {
            if(ModelState.IsValid)
            {
                var result = country.Id == 0 ?
                    await _countryService.CreateCountryAsync(country) :
                    await _countryService.EditCountryAsync(country);

                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost("countries/delete")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id != 0)
            {
                var result = await _countryService.DeleteAsync(id);
                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }



        [HttpGet("country:{countryId:int}/[action]")]
        public IActionResult Cities(int countryId)
        {
            return Ok(_cityService.GetCitiesByCountryId(countryId));
        }


        // this one don't work in swagger. 
        [HttpGet("{countryName}/[action]/")]
        public IActionResult Cities(string countryName)
        {
            if (string.IsNullOrEmpty(countryName))
            {
                return Ok(_cityService.GetAll());
            }
            Country country = _countryService.GetByName(countryName);
            if (country == null)
            {
                return BadRequest();
            }

            return Ok(_cityService.GetCitiesByCountryId(country.Id));
        }

        [HttpPost("cities/edit")]
        public async Task<IActionResult> EditCity(City city)
        {
            if (ModelState.IsValid)
            {
                var result = city.Id == 0 ?
                    await _cityService.CreateCityAsync(city) :
                    await _cityService.EditCityAsync(city);

                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost("cities/delete")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id != 0)
            {
                var result = await _cityService.DeleteCityAsync(id);
                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}