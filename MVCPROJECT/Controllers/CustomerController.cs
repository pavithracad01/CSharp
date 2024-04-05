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

    public IActionResult BrowseProduct()
    {
        return View("BrowseProduct", "_LayoutCustomer");
    }

    public IActionResult Checkout()
    {
        return View(" Checkout", "_LayoutCustomer");
    }
    public IActionResult Profile()
    {
        return View("Profile", "_LayoutCustomer");
    }
    public IActionResult ViewCart()
    {
        return View("ViewCart", "_LayoutCustomer");
    }
  }



  

    
    

    