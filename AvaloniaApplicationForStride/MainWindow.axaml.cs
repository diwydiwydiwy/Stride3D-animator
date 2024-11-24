using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Runtime.InteropServices;
using System;
using Avalonia.Platform;

namespace AvaloniaApplicationForStride
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Topmost = true;
        }

        private void InitializeComponent()
        {
            Closing += (s, e) =>
            {
                ((Window)s).Hide();
                e.Cancel = true;
            };
        }
    }
}