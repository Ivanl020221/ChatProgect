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

        #region ApiContext

        public static T ApiContext<T>(Controller controller, string paramsConnection) where T : class
        {
            return ApiContext<T, object>(controller, Metod.GET, Type.json, Connect.application, null, FromType.UriFullType, paramsConnection);
        }
        public static T ApiContext<T>(Controller controller, FromType fromType, string paramsConnection) where T : class
        {
            return ApiContext<T, object>(controller, Metod.GET, Type.json, Connect.application, null, fromType, paramsConnection);
        }
        public static T ApiContext<T, V>(Controller controller, Metod metod, V obj, FromType fromType, string paramsConnection) where T : class where V : class
        {
            return ApiContext<T, V>(controller, metod, Type.json, Connect.application, obj, fromType, paramsConnection);
        }
        public static T ApiContext<T, V>(Controller controller, Metod metod, Type type, V obj, FromType fromType, string paramsConnection) where T : class where V : class
        {
            return ApiContext<T, V>(controller, metod, type, Connect.application, obj, fromType, paramsConnection);
        }
        public static T ApiContext<T, V>(Controller controller, Metod metod, Type type, Connect connect, V obj, FromType fromType, string paramsConnection) where T : class where V : class
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    UpdateSettings();
                    string PathParam = SettingsClient(controller, paramsConnection, client, fromType, type, connect);
                    return PostOrGet<T, V>(metod, obj, client, PathParam, type);
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
        private static T PostOrGet<T, V>(Metod metod, V obj, WebClient client, string PathParam, Type type)
            where T : class
            where V : class
        {
            if (metod == Metod.GET)
            {
                return SerializeOnType<T>(type, client, PathParam);
            }
            else
            {
                return POSTMetod<T, V>(metod, obj, client, PathParam);
            }
        }
        private static string SettingsClient(Controller controller, string paramsConnection, WebClient client, FromType fromType, Type type, Connect connect)
        {
            string PathParam = GeneratePathParam(controller, fromType, paramsConnection);
            AddHeader(client, connect, type);
            return PathParam;
        }
        private static T SerializeOnType<T>(Type type, WebClient client, string PathParam) where T : class => type == Type.json
                                    ? GetJson<T>(client, PathParam)
                                    : Utilites.XmlDeSerialization<T>(client.DownloadString(PathParam));
        private static void AddHeader(WebClient client, Connect connect, Type type)
        {
            client.Headers.Add(HttpRequestHeader.ContentType, $"{Connect.application}/{Type.json}");
        }
        private static void UpdateSettings()
        {
            Properties.Settings.Default.Upgrade();
        }
        private static string GenerateFullPathParam(Controller controller, string paramsConnection)
        {
            return $"{Properties.Settings.Default.Path}/{controller}?{paramsConnection}";
        }
        private static string GeneratePathParam(Controller controller, FromType fromType, string paramsConnection)
        {
            return fromType == FromType.UriFullType ? GenerateFullPathParam(controller, paramsConnection) : $"{Properties.Settings.Default.Path}/{controller}/{paramsConnection}";
        }
        private static T POSTMetod<T, V>(Metod metod, V obj, WebClient client, string PathParam)
            where T : class
            where V : class
        {
            return Utilites.JsonDeSerialization<T>(client.UploadData(PathParam, metod.ToString(), Utilites.JsonSerialization(obj)));
        }
        private static T GetJson<T>(WebClient client, string PathParam) where T : class
        {
            return Utilites.JsonDeSerialization<T>(client.DownloadString(new Uri(PathParam)));
        }
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
