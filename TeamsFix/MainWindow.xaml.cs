using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using TeamsFix.Actions;

namespace TeamsFix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Window;
        private delegate void UpdateMessage(string msg);
        public delegate void ChangeButtonStatus(bool option);

        public MainWindow()
        {
            InitializeComponent();
            Window = this;
        }

        private void ButtonRepair(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                ButtonStatus(false);
                Setup.Repair();
                ButtonStatus(true);

            }).Start();
        }

        private void ButtonReinstall(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                ButtonStatus(false);
                Setup.Reinstall();
                ButtonStatus(true);

            }).Start();
        }

        private void ButtonGithub(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/vpess/teams-fix") { UseShellExecute = true });
        }

        public void EnableButtons(bool option)
        {
            Repair.IsHitTestVisible = option;
            Reinstall.IsHitTestVisible = option;
        }

        public void SetMessage(string msg)
        {
            LabelMsg.Content = msg;
            LabelMsg.Visibility = Visibility;
        }

        public void Message(string msg)
        {
            Dispatcher.BeginInvoke(new UpdateMessage(SetMessage), DispatcherPriority.Render, new object[] { msg });
            Logger.InsertInfo(msg);
            Thread.Sleep(1500);
        }

        public void ButtonStatus(bool option)
        {
            Dispatcher.BeginInvoke(new ChangeButtonStatus(EnableButtons), DispatcherPriority.Render, new object[] { option });
        }
    }
}