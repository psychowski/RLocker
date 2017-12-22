using RLockerClient.Model;
using RLockerClient.Model.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RLockerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RemoteLockerViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new RemoteLockerViewModel(new WindowsLockProvider(), new Connection());
            vm.Connect();
            
            vm.GenerateCorrelationId();
            vm.SetCorrelationId();
            tbConnectionId.Text = vm.CorrelationId;
            tbConnectionId.LostFocus += TbConnectionId_LostFocus;
        }

        private void TbConnectionId_LostFocus(object sender, RoutedEventArgs e)
        {
            vm.CorrelationId = tbConnectionId.Text;
            vm.SetCorrelationId();
        }
    }
}
