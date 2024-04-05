using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCPROJECT.Models;
using Microsoft.Data.SqlClient;

namespace MVCPROJECT.Controllers;

public class LoginController : Controller
  {

    SqlConnection con=new SqlConnection();

    SqlCommand com=new SqlCommand();
    

    SqlDataReader? dr;


    private readonly ILogger< LoginController> _logger;

    public LoginController(ILogger< LoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Admin()
    {
        return View("Dashboard","Admin");
    }
    public IActionResult Reports()
    {
        return View();
    }

    
     [HttpGet]
     public IActionResult Register()
    {
        return View();
    }


    void conStr(){
         con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=cad_ofs; User ID=CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True; ";
    }
    
    [HttpPost]
     public IActionResult RegisterDB(RegisterModel rmodel)
    {   
        conStr();
        con.Open();
        com.Connection=con;
       com.CommandText="insert into USER_REGISTER(FirstName,UserName ,PhoneNumber,EmailAddress,Password,Confirmpassword) values (@FirstName,@UserName,@PhoneNumber,@EmailAddress,@Password,@Confirmpassword) ";
      com.Parameters.AddWithValue("@FirstName",rmodel.FirstName);
       com.Parameters.AddWithValue("@UserName",rmodel.UserName);
       com.Parameters.AddWithValue("@PhoneNumber",rmodel.PhoneNumber);
       com.Parameters.AddWithValue("@EmailAddress",rmodel.EmailAddress);
       com.Parameters.AddWithValue("@Password",rmodel.Password);
       com.Parameters.AddWithValue("@Confirmpassword",rmodel.Confirmpassword);

        int rowAffected=com.ExecuteNonQuery();
        if(rowAffected>0){
            con.Close();
            return RedirectToAction("Login");
        }
        else{
            con.Close();
            return View("Error");
        }
        
    }
  


     public IActionResult Login()
    {
        return View();
    }


    public IActionResult VerifyLogin(LoginModel lmodel)
    {
       conStr();
        con.Open();
       com.Connection=con;
         com.CommandText="select * from ofs_log where UserName=@UserName and Password=@Password";
       com.Parameters.AddWithValue("@UserName", lmodel.UserName);
        com.Parameters.AddWithValue("@Password", lmodel.Password);

        dr=com.ExecuteReader();
if(dr.Read()){
       string? jobrolecheck=dr["jobrole"].ToString();
            con.Close();
         


            if(jobrolecheck=="Dashboard")
            {
                
            return RedirectToAction("Dashboard","Admin");
            }
            else if(jobrolecheck=="Admin"){
                
                return RedirectToAction("Dashboard","Admin");
            }
        else{
              con.Close();
            return View("Error");
        }

    }
           else{
              
                dr.Close();
                com.CommandText="select * from ofs_login where UserName=@UserName and password=@password";
                com.Parameters.AddWithValue("@UserName", lmodel.UserName);
                com.Parameters.AddWithValue("@Password", lmodel.Password);
                dr=com.ExecuteReader();
                if(dr.Read()){
                    con.Close();
                    return RedirectToAction("Dashboard","Trainee");
                }
                else{
                    con.Close();
                    return View("Error");
                 }
        }   
       
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    }