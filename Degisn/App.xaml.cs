using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace Degisn
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //SplashWindow splash = null;
        //MainWindow window = null;
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    Thread thread = new Thread(() =>
        //    {
        //        splash = new SplashWindow();
        //        splash.ShowDialog();
        //    });
        //    thread.SetApartmentState(ApartmentState.STA);

        //    thread.Start();
        //    window = new MainWindow();
        //    MainWindow = window;
        //    window.Show();
        //    window.ContentRendered += (s, ev) =>
        //    {
        //        CloseSplash();
        //        IntPtr handle = new WindowInteropHelper(MainWindow).Handle;
        //        SetForegroundWindow(handle);
        //    };
        //}

        //void CloseSplash()
        //{
        //    splash.Dispatcher.Invoke(() =>
        //    {
        //        splash.CloseAnimation();
        //    });
        //}

        //[DllImport("user32.dll")]
        //static extern bool SetForegroundWindow(IntPtr hnd);
    }
}
