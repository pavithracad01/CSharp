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
        return View();
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




    void connectionstring(){
        con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=CAD_OFS; User Id= CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True;";

    }
  

    public IActionResult VerifyLogin(LoginModel lmodel){
        connectionstring();
        con.Open();
        com.Connection=con;
        com.CommandText="select * from ofs_login  where Username='"+lmodel.username+"' and password='"+lmodel.password+"' ";
        dr=com.ExecuteReader();

        if(dr.Read()){
            con.Close();
            return View("Success");

        }
        else{
              con.Close();
            return View("Error");


        }
       
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
