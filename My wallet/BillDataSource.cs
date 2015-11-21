using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;


namespace My_wallet
{
    class BillDataSource
    {
        private const string FILENAME = "Bill.json";

   

        public async static Task<List<Bill>> readAllBills()
        {
            try
            {
                List<Bill> myData;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Bill>));

                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FILENAME))
                {
                    myData = (List<Bill>)serializer.ReadObject(stream);
                }
                return  myData;
            }
            catch (Exception ex)
            {
                return new List<Bill>();
            }
        }
        public async static Task<List<String>> readAllBillsString()
        {
            try
            {
                List<String> myDataString = new List<string>();
                List<Bill> myData;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Bill>));

                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FILENAME))
                {
                    myData = (List<Bill>)serializer.ReadObject(stream);
                }
                for (int i = 0; i < myData.Count(); i++)
                {
                    String billhistory =  myData[i].Des + " " + myData[i].Amount.ToString() ;
                    myDataString.Add(billhistory);

                }
                return myDataString;
            }
            catch (Exception ex)
            {
                return new List<String>();
            }
        }
        public static async Task<int> TotalAmount() {
            try
            {
                List<Bill> myData;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Bill>));

                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FILENAME))
                {
                    myData = (List<Bill>)serializer.ReadObject(stream);
                }
                return myData[myData.Count - 1].TotalAmount;
            }
            catch (Exception ex)
            {
                return 0;
            }
            
            
            /* List<Bill> myData = await readAllBills();
            if (myData.Count != 0)
            {
                return myData[myData.Count].TotalAmount;
            }
            else {
                return 0;
            }*/
        
        }
        public static async Task AddBill(Bill newBill)
        {

            List<Bill> myData = await readAllBills();

            newBill.ID = myData.Count;
            myData.Add(newBill);
           
            
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Bill>));

        using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FILENAME, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, myData);
            }
        
        }
        public static async Task EmptyHistory()
        {

            List<Bill> myData = await readAllBills();


            myData.Clear();


            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Bill>));

            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FILENAME, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, myData);
            }

        }


        internal static async Task Undo()
        {
            List<Bill> myData = await readAllBills();
            int remove = myData.Count;
            myData.RemoveAt(remove-1);


            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Bill>));

            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(FILENAME, CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, myData);
            }
        }
        public static async Task<int> MoneySpent() {
            try
            {
                int spent = 0;
                List<Bill> myData;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Bill>));

                using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FILENAME))
                {
                    myData = (List<Bill>)serializer.ReadObject(stream);
                }
                for (int i = 0; i < myData.Count(); i++)
                {
                    spent = spent + myData[i].spent;
                }
                    return spent;
            }
            catch (Exception ex)
            {
                return 0;
            }



        }

    }
}
