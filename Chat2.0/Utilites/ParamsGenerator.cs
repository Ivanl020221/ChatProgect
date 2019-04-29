using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat2._0.Utilites
{
    internal class ParamsGenerator
    {
        private readonly List<string> Params = new List<string>();

        #region CreateParams
        public static string CreateParams(string param, string value)
        {
            return $"{param}={value}";
        }

        public static string CreateParams(string param, long value)
        {
            return $"{param}={value}";
        }
        public static string CreateParams(string param, int value)
        {
            return $"{param}={value}";
        }

        public static string CreateParams(string param, decimal value)
        {
            return $"{param}={value}";
        }

        public static string CreateParams(string param, DateTime value)
        {
            return $"{param}={value}";
        }

        public static string CreateParams(string param, double value)
        {
            return $"{param}={value}";
        }

        public static string CreateParams(string param, TimeSpan value)
        {
            return $"{param}={value}";
        }
        #endregion
        public ParamsGenerator AddParams(params string[] Params)
        {
            foreach (var param in Params)
            {
                this.Params.Add(param);
            }
            return this;
        }

        public string GetParams()
        {
            return string.Join("&", this.Params);
        }
    }
}
