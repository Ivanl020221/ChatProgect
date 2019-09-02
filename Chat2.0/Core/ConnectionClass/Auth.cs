using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat2._0.Entity;
using Chat2._0.Utilites;

namespace Chat2._0.ConnectionClass
{
    internal class Auth
    {
        public Employee AuthMetod(string UserName, string Password)
        {
            return ApiConnect.ApiContext<Employee>
                (Controller.Auth, 
                new ParamsGenerator().AddParams(
                    ParamsGenerator.CreateParams("UserName", UserName), 
                    ParamsGenerator.CreateParams("Password", Password)).GetParams());
        }
    }
}
