using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MALSCS.New.Pages
{
    /// <summary>
    /// PageRegistryValue.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PageRegistryValue : Window
    {
        public PageRegistryValue()
        {
            InitializeComponent();

            string regKeytb = "";

            regKeytb = Convert.ToString(Registry.GetValue(@"HKEY_CURRENT_USER\Software\RegistryTest", "test", "EMPTY"));

            string text = System.IO.File.ReadAllText(regKeytb);

            Registry_Textblock.Text = text;
        }
    }
}
