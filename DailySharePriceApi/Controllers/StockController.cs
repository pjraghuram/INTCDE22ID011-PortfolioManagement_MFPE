using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailySharePriceApi.Models;

using DailySharePriceApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailySharePriceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StockController));

//
        private readonly StockContext context;

        public StockController(StockContext _context)
        {
            //
            context = _context;
        }
        /// <summary>
        /// Returning the Stock with the name equal to the one in parameter
        /// </summary>
        /// <param name="stockname"></param>
        /// <returns></returns>
        [HttpGet("{stockname}")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStockByNameAsync(string stockname)
        {            
            try
            {
                _log4net.Info("In StockController, HttpGet GetStockByName and " + stockname + " is searched");
                if (string.IsNullOrEmpty(stockname))
                {
                    _log4net.Info("StockController Null Name");
                    return BadRequest("Null or Empty Name is passed");
                }
                else
                {
                    Stock result = await context.Stocks.FirstOrDefaultAsync(m => m.StockName == stockname.ToUpper());
                    System.Threading.Thread.Sleep(5000);
                    //Stock result = _stockprovider.GetStockByNameProvider(stockname.ToUpper());
                    if (result == null)
                    {
                        _log4net.Info("StockController Stock " + stockname + " Not Found");
                        return NotFound( stockname +" Stock Not Found");
                    }
                    else
                    {
                        _log4net.Info("StockController Stock Found");
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                _log4net.Error("Stock Controller Exception Found - " + ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}
