using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace LearnUnitTest.UnitTestPractice;

public static class Extension
{
    public static string GetDescriptionOfEnum(this Enum enumModel)
        {
            var enumType = enumModel.GetType();
            var memberInfos = enumType.GetMember(enumModel.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes =
                  enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)valueAttributes[0]).Description;
            return description;
        }
    public static string TemplateFormat(this string value, object objValue)
    {
        try
        {
            var properties = objValue.GetType().GetProperties();
            foreach (PropertyInfo item in properties)
            {
                var key = "{{{" + item.Name + "}}}";
                if (value.Contains(key))
                {
                    var valueofkey = item.GetValue(objValue, null);
                    var valueofkeyStr = valueofkey?.ToString();
                    value = value.Replace(key, valueofkeyStr);
                }
            }
            return value;
        }
        catch
        {
            return value;
        }
    }

    public static string TemplateFormat(this string value, JObject jValue)
    {
        try
        {
            var properties = jValue.Properties().ToList().OrderBy(p => p.Name).ToList();
            foreach (JProperty item in properties)
            {
                var key = "{{{" + item.Name + "}}}";
                if (value.Contains(key))
                {
                    var valueofkey = item.Value;
                    var valueofkeyStr = valueofkey?.ToString();
                    value = value.Replace(key, valueofkeyStr);
                }
            }
            return value;
        }
        catch
        {
            return value;
        }
    }

}