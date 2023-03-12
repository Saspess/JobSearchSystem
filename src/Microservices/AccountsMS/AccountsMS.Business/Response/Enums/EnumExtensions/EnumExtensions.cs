using System.ComponentModel;

namespace AccountsMS.Business.Response.Enums.EnumExtensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            throw new ArgumentException("Description not found.", nameof(enumValue));
        }
    }
}
