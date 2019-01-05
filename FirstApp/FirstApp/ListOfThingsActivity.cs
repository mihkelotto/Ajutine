using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Widget.AdapterView;

namespace FirstApp
{
    [Activity(Label = "ListOfThingsActivity")]
    public class ListOfThingsActivity : Activity
    {
        List<Car> ListOfCars;
        int item;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.list_layout);
            // Create your application here
            var listView = FindViewById<ListView>(Resource.Id.listView1);
            var kwEditText = FindViewById<EditText>(Resource.Id.editText3);
            var addButton = FindViewById<Button>(Resource.Id.button1);
            var updateButton = FindViewById<Button>(Resource.Id.button2);
            var deleteButton = FindViewById<Button>(Resource.Id.button3);

            var listOfCars = GenerateCars();

            ListOfCars = listOfCars.ToList();
            listView.Adapter = new CustomAdapter(this, ListOfCars);

                listView.ItemClick += (object sender, ItemClickEventArgs e) =>
                {

                    var changelistActivity = new Intent(this, typeof(ListOfThingsActivity));
                    item = (int)listView.Adapter.GetItemId(e.Position);
                    Car m = ListOfCars.ElementAt(item);
                    kwEditText.Text = m.Kw;
                //string str = item.ToString();
                //Toast.MakeText(this, str, ToastLength.Short).Show();
                /* int item = (int)listView.Adapter.GetItemId(e.Position);
                 Car listItem = ListOfCars.ElementAt(item);
                 ListOfCars.Remove(listItem);
                 listView.Adapter = new CustomAdapter(this, ListOfCars); */

                };



            /*  listView.Click += (object sender, EventArgs e) =>
              {
                  Car item = items.ElementAt(position);
                  items.Remove(item);
              };*/
            updateButton.Click += delegate
            {
                var car = new Car();
                car.Kw = kwEditText.Text;
                ListOfCars.RemoveAt(item);
                //string s = m.ToString();
                //Toast.MakeText(this, s, ToastLength.Short).Show();
                ListOfCars.Insert(item, car);
                listView.Adapter = new CustomAdapter(this, ListOfCars);

            };

            deleteButton.Click += delegate
            {
                ListOfCars.RemoveAt(item);
                kwEditText.Text = "";
                listView.Adapter = new CustomAdapter(this, ListOfCars);
            };

            addButton.Click += delegate
            {
                var car = new Car();
                car.Kw = kwEditText.Text;
                ListOfCars.Add(car);
                kwEditText.Text = "";
                listView.Adapter = new CustomAdapter(this, ListOfCars);

            };


        }

        private List<Car> GenerateCars()
        {
            var listOfCars = new List<Car>();
            return listOfCars;
        }


    }
}