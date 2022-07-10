using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DailyMutualFundNAVMicroservice.Repository;
using DailyMutualFundNAVMicroservice.Models;

using System.Net;
using Microsoft.EntityFrameworkCore;

namespace DailyMutualFundNAVMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutualFundNAVController : ControllerBase
    {
        static readonly log4net.ILog _log4net=log4net.LogManager.GetLogger(typeof(MutualFundNAVController));
       // private readonly IMutualFundProvider mutualFundProvider;
        private readonly MutualFundContext context;
        public MutualFundNAVController(MutualFundContext _context)
        {
            _log4net.Info("MutualFundNAVController Initiated");
            // mutualFundProvider = _mutualFundProvider;
            context = _context;
        }
        [HttpGet("{mutualFundName}")]
        public async Task<ActionResult<IEnumerable<MutualFundContext>>> GetMutualFundDetailsByName(string mutualFundName)
        {
            try
            {
                _log4net.Info("In StockController, HttpGet GetStockByName and " + mutualFundName + " is searched");
                if (string.IsNullOrEmpty(mutualFundName))
                {
                    _log4net.Info("StockController Null Name");
                    return BadRequest("Null or Empty Name is passed");
                }
                else
                {
                    MutualFundDetails result =await  context.MutualFundDetails.FirstOrDefaultAsync(m=>m.MutualFundName==mutualFundName.ToUpper());
                    System.Threading.Thread.Sleep(100);
                    //Stock result = _stockprovider.GetStockByNameProvider(stockname.ToUpper());
                    if (result == null)
                    {
                        _log4net.Info("StockController Stock " + mutualFundName + " Not Found");
                        return NotFound(mutualFundName + " Stock Not Found");
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
                return BadRequest(ex.Message);
            }
        }
    }
}