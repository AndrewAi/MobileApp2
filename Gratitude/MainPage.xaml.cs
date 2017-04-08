using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Gratitude
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private DispatcherTimer timer;
        private DispatcherTimer timer2;

        private int basetime;
        private int startTime;


        public MainPage()
        {
            this.InitializeComponent();


            this.NavigationCacheMode = NavigationCacheMode.Required;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            timer.Tick += timer_Tick;

            this.NavigationCacheMode = NavigationCacheMode.Required;
            timer2 = new DispatcherTimer();
            timer2.Interval = new TimeSpan(0, 0, 1);
            timer2.Tick += timer2_Tick;

        }

        private async void timer_Tick(object sender, object e)
        {

            basetime = basetime - 1;

            if (basetime == 0)
            {
                timer.Stop();

                my.Play();



            }

        }


        private async void timer2_Tick(object sender, object e)
        {

            startTime = startTime - 1;

            if (startTime == 0)
            {
                timer2.Stop();

                my.Play();


            }

        }



        private async void button_Click(object sender, RoutedEventArgs e)
        {

            var res = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();

            Random rnd = new Random();

            int mIndex = rnd.Next(1, 33);
            MessageDialog showDialog = new MessageDialog(res.GetString(mIndex.ToString()));
            showDialog.Commands.Add(new UICommand("Ok")
            {
                Id = 0
            });
         
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();

         


        }

       /* private async void button_Click2(Object sender, RoutedEventArgs e)
        {
            int anInteger;
            //anInteger = Convert.ToInt32(TimeBox.Text);
            anInteger = int.Parse(TimeBox.Text);


        }
        */


        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine("btn3");

            int timeInt;
           
            timeInt = int.Parse(TimeBox.Text);

            //String Key = timeInt.ToString().PadRight(5, '0');

            //int i = 321;
            //Key = i.ToString().PadLeft(10, '0');


            basetime = timeInt;
            timer.Start();



            MessageDialog showDialog = new MessageDialog("Get into a comfortable position, and ready to meditate. The start bell will sound in 10 seconds,"
                                                           + "And the ending bell will sound in " + timeInt + " minutes. enjoy! breath in & out through the nose focusing on the breath coming in and out. :)");
            showDialog.Commands.Add(new UICommand("Ok")
            {
                Id = 0
            });

            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();

            startTime = 10;
            timer2.Start();

        }



      


    }
}
