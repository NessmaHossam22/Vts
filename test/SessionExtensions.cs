using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace YourProjectName.Extensions
{
    public static class SessionExtensions
    {
        // دالة لحفظ كائن في الجلسة بصيغة JSON
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // دالة لاسترجاع كائن من الجلسة بصيغة JSON
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
