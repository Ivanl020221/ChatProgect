using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat2._0.Entity
{
    class DepatmentsModel : Departments
    {
        private bool? _Select;
        
        public bool? Select
        {
            get { return _Select; }
            set
            {
                _Select = value;
                OnPropertyChanged("Select");
            }
        }
    }
}
