using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat2._0.Entity;
using Chat2._0.Utilites;

namespace Chat2._0.ConnectionClass
{
    class Search
    {
        public IEnumerable<DepatmentsModel> Departments =>
            ApiConnect.ApiContext<IEnumerable<DepatmentsModel>>(Controller.Search,FromType.UriContent, "");

        public IEnumerable<Employee> SearchEmployees(string Departmens, string SearchName) =>
            ApiConnect.ApiContext<IEnumerable<Employee>>(
                Controller.Search, 
                new ParamsGenerator().AddParams(
                        ParamsGenerator.CreateParams("Departmens", Departmens), 
                        ParamsGenerator.CreateParams("SearchName", SearchName)
                    ).GetParams());
    }
}
