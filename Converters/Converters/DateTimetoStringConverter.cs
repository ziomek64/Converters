using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace Converters
{
    /// <summary>
    ///     Converts a DateTime to string value.
    /// </summary>
    public class DateTimetoStringConverter : IValueConverter
    {
        /// <summary>
        /// Default format used when parameter is not provided.
        /// Example string with this format - 10/31/2008 5:04 PM
        /// </summary>
        private const string DefaultFormat = "G";
        
        /// <summary>
        /// List of compatible formats.
        /// See https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=net-5.0 for more information.
        /// </summary>
        private static readonly string[] Formats = {"d", "D", "f", "F", "g", "G", "m", "o", "r",
            "s", "t", "T", "u", "U", "Y"};
        
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The type of the binding target property. This is not implemented.</param>
        /// <param name="parameter">Additional parameter for the converter to handle as a format. If not provided, null or empty it is "G" format by default.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not DateTime datetime)
                throw new ArgumentException("Value is not a valid DateTime.");

            string format;

            string parameterString = parameter?.ToString();

            if (string.IsNullOrEmpty(parameterString))
            {
                format = DefaultFormat;
            }
            else
            {
                if (!(Formats.Contains(parameterString)))
                    throw new ArgumentException("Format parameter not supported.");
                
                format = parameterString;
            }
            
            return datetime.ToString(format, culture);
        }
        
        /// <summary>
        /// This method is not implemented and will throw a <see cref="NotImplementedException"/>.
        /// </summary>
        /// <param name="value">N/A</param>
        /// <param name="targetType">N/A</param>
        /// <param name="parameter">N/A</param>
        /// <param name="culture">N/A</param>
        /// <returns>N/A</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}