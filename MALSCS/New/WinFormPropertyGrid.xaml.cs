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
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using WiseScopeDemo.New.Pages;

namespace WiseScopeDemo.New
{
   
    /// <summary>
    /// WinFormPropertyGrid.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WinFormPropertyGrid : Window
    {
        private Machine machine;

        public WinFormPropertyGrid()
        {
            InitializeComponent();

            machine = App.cmachine;
         

            winFormPropertyGrid.SelectedObject = machine.mals_ctr;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            winFormPropertyGrid.SelectedObject = machine.mals_ctr;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            winFormPropertyGrid.SelectedObject = machine.lighting_ctr;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
