using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Chat2._0.Utilites
{
    internal class ApiConnect
    {

        private static readonly string Path = Chat2._0.Properties.Settings.Default.Path;

        #region ApiContext

        public static T ApiContext<T>(Controller controller, string paramsConnection) where T : class
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string PathParam = $"{Path}/{controller}?{paramsConnection}";
                    client.Headers.Add(HttpRequestHeader.ContentType, $"{Connect.application}/{Type.json}");
                    return Utilites.JsonDeSerialization<T>(client.DownloadString(new Uri(PathParam)));
                }
            }
            catch
            {
                throw;
            }

        }

        public static T ApiContext<T>(Controller controller, FromType fromType, string paramsConnection) where T : class
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string PathParam = fromType == FromType.UriFullType ? $"{Path}/{controller}?{paramsConnection}" : $"{Path}/{controller}/{paramsConnection}";
                    client.Headers.Add(HttpRequestHeader.ContentType, $"{Connect.application}/{Type.json}");
                    return Utilites.JsonDeSerialization<T>(client.DownloadString(new Uri(PathParam)));
                }
            }
            catch
            {
                throw;
            }

        }

        public static T ApiContext<T, V>(Controller controller, Metod metod, V obj, FromType fromType, string paramsConnection) where T : class where V : class
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string PathParam = fromType == FromType.UriFullType ? $"{Path}/{controller}?{paramsConnection}" : $"{Path}/{controller}/{paramsConnection}";
                    client.Headers.Add(HttpRequestHeader.ContentType, $"{Connect.application}/{Type.json}");
                    if (metod == Metod.GET)
                    {
                        return Utilites.JsonDeSerialization<T>(client.DownloadString(PathParam));
                    }
                    else
                    {
                        try
                        {
                            return Utilites.JsonDeSerialization<T>(client.UploadData(PathParam, metod.ToString(), Utilites.JsonSerialization(obj)));
                        }
                        catch (ArgumentNullException)
                        {
                            return null;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static T ApiContext<T, V>(Controller controller, Metod metod, Type type, V obj, FromType fromType, string paramsConnection) where T : class where V : class
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string PathParam = fromType == FromType.UriFullType ? $"{Path}/{controller}?{paramsConnection}" : $"{Path}/{controller}/{paramsConnection}";
                    client.Headers.Add(HttpRequestHeader.ContentType, $"{Connect.application}/{type}");
                    if (metod == Metod.GET)
                    {
                        return type == Type.json
                            ? Utilites.JsonDeSerialization<T>(client.DownloadString(PathParam))
                            : Utilites.XmlDeSerialization<T>(client.DownloadString(PathParam));
                    }
                    else
                    {
                        try
                        {
                            return Utilites.JsonDeSerialization<T>(client.UploadData(PathParam, metod.ToString(), Utilites.JsonSerialization(obj)));
                        }
                        catch (ArgumentNullException)
                        {
                            return null;
                        }
                    }
                }

            }
            catch
            {
                throw;
            }
        }

        public static T ApiContext<T, V>(Controller controller, Metod metod, Type type, Connect connect, V obj, FromType fromType, string paramsConnection) where T : class where V : class
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string PathParam = fromType == FromType.UriFullType ? $"{Path}/{controller}?{paramsConnection}" : $"{Path}/{controller}/{paramsConnection}";
                    client.Headers.Add(HttpRequestHeader.ContentType, $"{connect}/{type}");
                    if (metod == Metod.GET)
                    {
                        return type == Type.json
                            ? Utilites.JsonDeSerialization<T>(client.DownloadString(PathParam))
                            : Utilites.XmlDeSerialization<T>(client.DownloadString(PathParam));
                    }
                    else
                    {
                        try
                        {
                            return Utilites.JsonDeSerialization<T>(client.UploadData(PathParam, metod.ToString(), Utilites.JsonSerialization(obj)));
                        }
                        catch (ArgumentNullException)
                        {
                            return null;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }

    public static class MyFunc
    {
        public static int ToInt(this object value) => Convert.ToInt32(value);
        public static long ToLong(this object value) => Convert.ToInt64(value);
        public static decimal ToDecimal(this object value) => Convert.ToDecimal(value);
        public static double ToDouble(this object value) => Convert.ToDouble(value);
    }

    public enum Metod
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum Controller
    {
        Main,
        Auth,
        ChatRoom,
        Search
    }

    public enum Type
    {
        json,
        xml
    }

    public enum FromType
    {
        UriContent,
        UriFullType
    }

    public enum Connect
    {
        text,
        application
    }
}
