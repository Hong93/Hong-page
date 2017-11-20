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
using WiseScopeDemo.New.Pages;

namespace WiseScopeDemo.New
{
    /// <summary>
    /// PagePropertyGrid.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PagePropertyGrid : Window
    {
        private Machine machine;
        //private MALSController mals_ctr;
        //private LightingController lighting_ctr;


        public PagePropertyGrid()
        {
            InitializeComponent();
            machine = App.cmachine;

            propertyGrid1.SelectedObject = machine.mals_ctr;
        }

        private void MALS_Property_Click(object sender, RoutedEventArgs e)
        {
            propertyGrid1.SelectedObject = machine.mals_ctr;
        }

        private void Lighting_Property_Click(object sender, RoutedEventArgs e)
        {
            propertyGrid1.SelectedObject = machine.lighting_ctr;
        }

       
    }
}
