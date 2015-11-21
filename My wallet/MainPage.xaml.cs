using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace My_wallet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
        //<swip handler>
        private async void PutHistory() {

            
            mySpending.Items.Clear();
            List<String> myDataString = await BillDataSource.readAllBillsString();
            //  mySpending.Items.Add("item test");
            int amount = await BillDataSource.MoneySpent();
            moneyspent.Text = amount.ToString();
            for (int i = 0; i < myDataString.Count(); i++)
            {
                mySpending.Items.Add(myDataString[i]);

            }
        }
        private async void PutAmount() {
            int amount = await BillDataSource.TotalAmount();
            myMoney.Text = amount.ToString();
        }
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (main_pivot.SelectedIndex)
            {
                case 0:
                    Select0();
                    PutAmount();
                    break;
                case 1:
                    Select1();
                    PutHistory();


                    break;
                default:
                    break;
            }
         
        }
        //</swip handler>
        //<selecting methods>
        void Select0()
        {
            wallet.Opacity = 1.0;
            his.Opacity = 0.5;
            
            main_pivot.SelectedIndex = 0;
        }
        void Select1()
        {
            wallet.Opacity = 0.5;
            his.Opacity = 1.0;
            
            main_pivot.SelectedIndex = 1;
        }

        private void wallet_tap(object sender, TappedRoutedEventArgs e)
        {
            Select0();
        }

        private void his_tap(object sender, TappedRoutedEventArgs e)
        {
            Select1();
        }
        private Boolean valid() {
            if (Money.Text == "" || MoneyFor.Text == "" || int.Parse(Money.Text) == 0)
            {
                if (Money.Text == "")
                {
                    prob.Text = "* please enter an amount !";
                }
                else {
                    if (int.Parse(Money.Text) == 0)
                    {
                        prob.Text = "* please enter a valid amount !";
                    }
                }
                if (MoneyFor.Text == "")
                {
                    prob.Text = "* please enter description !";
                }
                if (Money.Text == "" && MoneyFor.Text == "")
                {
                    prob.Text = "* please enter an amount and a description !";
                }

               
                return false;
            }

            else
            { return true;  }
        }
        private async void addMoney(object sender, RoutedEventArgs e)
        {
            if (valid()) 
            {
                await BillDataSource.AddBill(new Bill()
                {
                    Amount = int.Parse(Money.Text),
                    Des = "(add) " + MoneyFor.Text,
                    TotalAmount = int.Parse(myMoney.Text) + int.Parse(Money.Text),
                    spent = 0
                });
                int money = int.Parse(myMoney.Text) + int.Parse(Money.Text);
                myMoney.Text = money.ToString();
                Money.Text = "";
                MoneyFor.Text = "";
                prob.Text = "";
            }
        }

        private async void subMoney(object sender, RoutedEventArgs e)
        {
            if(myMoney.Text == "0"){
                prob.Text = "* you have no money can't subtract !";
                Money.Text = "";
                MoneyFor.Text = "";
            }
            else{
            if (valid())
          
            {
                    await BillDataSource.AddBill(new Bill()
                    {
                        Amount = int.Parse(Money.Text),
                        Des = "(sub) " + MoneyFor.Text,
                        TotalAmount = int.Parse(myMoney.Text) - int.Parse(Money.Text),
                        spent = int.Parse(Money.Text)
                });
                int money = int.Parse(myMoney.Text) - int.Parse(Money.Text);
                myMoney.Text = money.ToString();
                Money.Text = "";
                MoneyFor.Text = "";
                prob.Text = "";
            }
            }
        }

      

        private async void emptyHistory_Click(object sender, RoutedEventArgs e)
        {
            await BillDataSource.EmptyHistory();
            mySpending.Items.Clear();
        }

        private async void Undo_Click(object sender, RoutedEventArgs e)
        {
            await BillDataSource.Undo();
            PutHistory();
        }

    }
}
