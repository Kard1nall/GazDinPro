using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GazDinPro.Models;
using GazDinPro.Models.HomeViewModels;


namespace GazDinPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationContext _context;
        public HomeController(ApplicationContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Index(InputDataModel input, bool isSaveInputs, int? inputId)
        {
            input.DateOfResult = DateTime.Now;

            if (isSaveInputs)
            {
                _context.InputData.Add(input);
                await _context.SaveChangesAsync();

            }
            if (inputId != null)
            {
                var existInputData = _context.InputData.FirstOrDefault(x => x.Id == inputId);

                if (existInputData != null)
                {

                    //existInputData.DateOfResult = DateTime.Now;


                    existInputData.C4 = input.C4;
                    existInputData.C5 = input.C5;
                    existInputData.C6 = input.C6;
                    existInputData.C7 = input.C7;
                    existInputData.C8 = input.C8;
                    existInputData.C9 = input.C9;
                    existInputData.C10 = input.C10;
                    existInputData.C11 = input.C11;
                    existInputData.C12 = input.C12;
                    existInputData.C13 = input.C13;
                    existInputData.C14 = input.C14;
                    existInputData.C15 = input.C15;

                    existInputData.C18 = input.C18;
                    existInputData.C19 = input.C19;
                    existInputData.C20 = input.C20;
                    existInputData.C21 = input.C21;
                    existInputData.C22 = input.C22;
                    existInputData.C23 = input.C23;
                    existInputData.C24 = input.C24;
                    existInputData.C25 = input.C25;

                    existInputData.C28 = input.C28;
                    existInputData.C29 = input.C29;
                    existInputData.C31 = input.C31;
                    existInputData.C32 = input.C32;
                    existInputData.C33 = input.C33;
                    existInputData.C34 = input.C34;
                    existInputData.C35 = input.C35;
                    existInputData.C36 = input.C36;
                    existInputData.C37 = input.C37;
                    existInputData.C38 = input.C38;
                    existInputData.C39 = input.C39;
                    existInputData.C40 = input.C40;
                    existInputData.C41 = input.C41;
                    existInputData.C42 = input.C42;
                    existInputData.C43 = input.C43;
                    existInputData.C44 = input.C44;
                    existInputData.C45 = input.C45;

                    existInputData.C47 = input.C47;

                    existInputData.C49 = input.C49;

                    existInputData.C52 = input.C52;

                    existInputData.C56 = input.C56;
                    existInputData.C57 = input.C57;
                    existInputData.C58 = input.C58;
                    existInputData.C59 = input.C59;
                    existInputData.C60 = input.C60;
                    existInputData.C61 = input.C61;
                    existInputData.C62 = input.C62;
                    existInputData.C63 = input.C63;
                    existInputData.C64 = input.C64;
                    existInputData.C65 = input.C65;

                    existInputData.C67 = input.C67;
                    existInputData.C68 = input.C68;
                    existInputData.C69 = input.C69;

                    existInputData.I40 = input.I40;
                    existInputData.J40 = input.J40;
                    existInputData.K40 = input.K40;
                    existInputData.L40 = input.L40;
                    existInputData.M40 = input.M40;

                    existInputData.I45 = input.I45;
                    existInputData.J45 = input.J45;
                    existInputData.K45 = input.K45;
                    existInputData.L45 = input.L45;

                    existInputData.J50 = input.J50;
                    existInputData.K50 = input.K50;
                    existInputData.L50 = input.L50;
                    _context.InputData.Update(existInputData);
                    await _context.SaveChangesAsync();
                }

            }

            return RedirectToAction("Result", input);
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                InputDataModel input = await _context.InputData.FirstOrDefaultAsync(p => p.Id == id);

                ViewData["Variant"] = input.Id;
                ViewData["VariantDateTime"] = input.DateOfResult;

                ViewBag.IsSavedInputData = true;

                if (input != null)
                    return View(input);
            }
            else
            {
                InputDataModel inputData = InputDataModel.GetDefaultData();

                ViewBag.IsSavedInputData = false;

                return View(inputData);
            }
            return NotFound();
        }

        public IActionResult Result(InputDataModel input)
        {
            ResultViewModel viewModel = new ResultViewModel(input);
            ViewBag.isProject = true;

            return View(viewModel);
        }

        public async Task<IActionResult> Inputs()
        {
            var inputData = await _context.InputData.ToListAsync();

            return View(inputData);
        }

        public IActionResult ComparisonIndex()
        {
            return View();
        }

        [HttpPost]


        public async Task<IActionResult> Comparison()
        {
            ViewBag.Inputs = await _context.InputData.ToListAsync();

            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
