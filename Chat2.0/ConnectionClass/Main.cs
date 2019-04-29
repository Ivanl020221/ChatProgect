using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat2._0.Entity;
using Chat2._0.Utilites;

namespace Chat2._0.ConnectionClass
{
    class Main
    {
        public IEnumerable<SelectAllMessage> MainMetod(long UserId) => ApiConnect.ApiContext<IEnumerable<SelectAllMessage>>(Controller.Main, new ParamsGenerator().AddParams(ParamsGenerator.CreateParams("UserId", UserId)).GetParams());
    }
}
