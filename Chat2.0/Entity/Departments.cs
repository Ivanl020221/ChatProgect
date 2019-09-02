using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat2._0.Entity
{
    internal class Departments : Core.NotifyPropertyChanged
    {
        private long _IdDepartments;

        private string _Name;

        public long IdDepartments
        {
            get { return _IdDepartments; }
            set
            {
                _IdDepartments = value;
                OnPropertyChanged("IdDepartments");
            }
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
