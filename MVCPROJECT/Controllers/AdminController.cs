using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCPROJECT.Models;
using Microsoft.Data.SqlClient;

namespace MVCPROJECT.Controllers;

public class AdminController : Controller
  {

    SqlConnection con=new SqlConnection();

    SqlCommand com=new SqlCommand();
    

    SqlDataReader? dr;


    private readonly ILogger< AdminController> _logger;

    public AdminController(ILogger< AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult Customer()
    {
        return View("Customer", "_LayoutAdmin");
    }

    public IActionResult Dashboard()
    {
        return View("Dashboard", "_LayoutAdmin");
    }
    public IActionResult Order()
    {
        return View("Order", "_LayoutAdmin");
    }
    public IActionResult Product()
    {
        return View("Product", "_LayoutAdmin");
    }
    public IActionResult Reports()
    {
        return View("Reports", "_LayoutAdmin");
    }
    
    public IActionResult ProductReg()
    {
        return View("ProductReg", "_LayoutAdmin");
    }
    



  

    
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
 }
