using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BE;
namespace PLWPF_Updated
{
    class BoolianToY_NConverter : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			switch (Enum.Parse(typeof(Y_N),value.ToString()))
			{
				case Y_N.Yes:
					return true;
				case Y_N.No:
					return false;
			}
			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
			{
				if ((bool)value == true)
					return Y_N.Yes;
				else
					return Y_N.No;
			}
			return Y_N.No;
		}
	}
}
