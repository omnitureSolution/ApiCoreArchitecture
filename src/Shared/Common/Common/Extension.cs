using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Omniture.Shared.Common
{
    public static class Extension
    {
        public static DateTime ParseToDate(this DateTime dateTime, string date) => DateTime.Now.ParseToDate(date, DateTime.Now);

        public static DateTime ParseToDate(this DateTime dateTime, string date, DateTime defaultDate)
        {
            if (DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime returnDate))
                return returnDate;
            return defaultDate;
        }


        public static DateTime UtcDate(this DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Unspecified)
                dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            return dateTime.ToUniversalTime();
        }
        public static DateTime? UtcDate(this DateTime? dateTime)
        {
            if (dateTime?.Kind == DateTimeKind.Unspecified)
                dateTime = DateTime.SpecifyKind(Convert.ToDateTime(dateTime), DateTimeKind.Utc);
            return dateTime?.ToUniversalTime();
        }

        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string ToJsonString<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });

        }

        public static T ToObject<T>(this string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public static T CopyTo<T>(this T Base, T New)
        {
            if (Base == null)
            {
                return New;
            }

            foreach (PropertyInfo oldProp in Base.GetType().GetProperties())
            {
                if (New.GetType().GetProperties().Count(t => t.Name == oldProp.Name) > 0)
                {
                    PropertyInfo newProp = New.GetType().GetProperty(oldProp.Name);
                    if (newProp != null)
                    {
                        object propValue = oldProp.GetValue(Base, null);
                        newProp.SetValue(New, propValue, null);
                    }
                }
            }

            foreach (FieldInfo oldField in Base.GetType().GetFields())
            {
                if (New.GetType().GetFields().Count(t => t.Name == oldField.Name) > 0)
                {
                    FieldInfo newField = New.GetType().GetField(oldField.Name);
                    if (newField != null)
                    {
                        object fieldValue = oldField.GetValue(Base);
                        newField.SetValue(New, fieldValue);
                    }
                }
            }
            return New;
        }

        public static Boolean IsSameObject(this object currentObject, object newobject)
        {
            foreach (PropertyInfo property in currentObject.GetType().GetProperties())
            {
                object value1 = property.GetValue(currentObject, null);
                object value2 = property.GetValue(newobject, null);
                if (value1 == null && value2 == null)
                    continue;
                if ((value1 == null && value2 != null) || (value1 != null && value2 == null))
                    return false;
                if (!value1.Equals(value2))
                {
                    return false;
                }

            }
            return true;
        }
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
