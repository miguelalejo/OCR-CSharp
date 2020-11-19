using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TabControlStyle
{
    /// <summary>
    /// Lógica de interacción para TabPapeWPF.xaml
    /// </summary>
    public partial class TabPapeWPF : UserControl
    {
        public TabPapeWPF()
        {
            InitializeComponent();
        }
        public delegate void ClickHandler(object sender, EventArgs e);
        public event EventHandler ClickBotonWPF;

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            ClickBotonWPF(sender, e);

        }
    }
}
