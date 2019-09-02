using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chat2._0.Utilites
{
    public delegate void SetPage(Page page);


    internal class Utilites
    {
        public static SetPage SetPage;

        public static void SetPageUtilite(Page page)
        {
            if (!(SetPage is null))
                SetPage(page);
        }

        public static T XmlDeSerialization<T>(string Xml) where T : class
        {
            if (Xml is null)
            {
                throw new ArgumentNullException(nameof(Xml), "Element is null");
            }
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            return serializer.ReadObject(new MemoryStream(Encoding.Default.GetBytes(Xml.Replace("http://schemas.datacontract.org/2004/07/ChatAPI.Controllers", "http://schemas.datacontract.org/2004/07/Chat2._0.Entity")))) is T obj ? obj : null;
        }

        #region JsonSerealization
        public static T JsonDeSerialization<T>(string Json) where T : class
        {
            if (Json is null)
            {
                throw new ArgumentNullException(nameof(Json), "Element is null");
            }
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return serializer.ReadObject(new MemoryStream(Encoding.Default.GetBytes(Json))) is T obj ? obj : null;
        }

        public static T JsonDeSerialization<T>(byte[] JsonByte) where T : class
        {
            if (JsonByte is null)
            {
                throw new ArgumentNullException(nameof(JsonByte), "Element is null");
            }
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return serializer.ReadObject(new MemoryStream(JsonByte)) is T obj ? obj : null;
        }
        #endregion

        public static byte[] JsonSerialization<T>(T obj) where T : class
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj), "Element is null");
            }
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                return ms.ToArray();
            }
        }
    }
}
