using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace WayOfTheSamurai4SaveEditor.Models
{
    public class EnumDisplayTypeConverter(Type type) : EnumConverter(type)
    {
        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType != typeof(string))
            {
                throw new NotSupportedException();
            }

            if (value == null)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            var name = value.ToString();
            if (name == null)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            var field = value.GetType().GetField(name);
            if (field == null)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }

            var attribute = field.GetCustomAttribute<DescriptionAttribute>(false);
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
