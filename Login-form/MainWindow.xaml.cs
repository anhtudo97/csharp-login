using System.Security.Permissions;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using xNet;

namespace Login_form
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static HttpClient client = new HttpClient();
        

        
        public MainWindow()
        {
            InitializeComponent();
            RegistryApp();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool VerifyUser(string username, string password)
        {
            return true;
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(txtUsername.Text);
            Console.WriteLine(txtPassword.Password);

            //HttpRequest http = new HttpClient();

            //string html = http.Get(").ToString();
            HttpResponseMessage response = client.GetAsync("https://3d4884f9d5cbfde90b7e62fee8a11728.m.pipedream.net").Result;
            string responseBody = await response.Content.ReadAsStringAsync();
            MessageBox.Show(responseBody);

            //File.WriteAllText("res.txt", responseString);

            //if (VerifyUser(txtUsername.Text, txtPassword.Password))
            //{
            //    MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        public void RegistryApp()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}");
            key.SetValue("","TuanhStorage123", RegistryValueKind.String);
            key.SetValue("System.IsPinnedToNameSpaceTree", 0x1, RegistryValueKind.DWord);
            key.SetValue("SortOrderIndex", 0x42, RegistryValueKind.DWord);

            RegistryKey defaulticon = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\DefaultIcon ");
            defaulticon.SetValue("", @"%C:\Windows%/system32/imageres.dll,-104", RegistryValueKind.ExpandString);

            RegistryKey inProcServer32 = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\InProcServer32");
            inProcServer32.SetValue("", @"%C:\Windows%\system32\shell32.dll", RegistryValueKind.ExpandString);

            RegistryKey instance = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\Instance");
            instance.SetValue("CLSID", "d05671ab-5883-4ae5-ba5d-3d491d9c1465", RegistryValueKind.String);

            RegistryKey initPropertyBag = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\Instance\InitPropertyBag");
            initPropertyBag.SetValue("Attributes", 0x11, RegistryValueKind.DWord);
            initPropertyBag.SetValue("TargetFolderPath ", @"%C:\Users\spd09%\MyCloudStorageApp", RegistryValueKind.ExpandString);

            RegistryKey shellFolder  = Registry.CurrentUser.CreateSubKey(@"Software\Classes\CLSID\{ebce018c-ab57-48a3-8ecb-b95827530ad8}\ShellFolder");
            shellFolder.SetValue("FolderValueFlags", 0x28, RegistryValueKind.DWord);
            //Step 10
            //shellFolder.SetValue("Attributes", 0xF080004D, RegistryValueKind.DWord);
            
            RegistryKey nameSpace  = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{ebce018c-ab57-48a3-8ecb-b95827530ad8}");
            nameSpace.SetValue("", "TuanhStorage123", RegistryValueKind.String);
        }


    }
}
