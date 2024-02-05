1)Install Microsoft Visual Studio (Visual Studio)
2)Clone repository
3)You will need SQL Server Management Studio (SSMS) setup
4)Change Dekstop name in connection string in KirilsShop/appsettings.json :
          "CarShContext": "Server=//YOUR DESKTOP NAME;Database=CarShop.Data;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
5)Then you might be able to make migration - 
              1)Open Package Manager Console.
              2)Type Add-Migration First_Migration
              3)Then Update-Database
              4)You are all set
6)Now u can Create, Edit, Delete objects (They should be already created by DB seed, if not, something went wrong. In this case contact me) 
          
