using System.Globalization;
using System.Linq;

public static class Convertor
{
    public static string FloatToDolar(float value){
        return "$" + value.ToString("C", CultureInfo.CurrentCulture).Substring(0, value.ToString("C", CultureInfo.CurrentCulture).Count() - 2);
    }
}
