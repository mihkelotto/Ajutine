﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using static Android.Widget.AdapterView;

namespace FirstApp
{
    public class CustomAdapter : BaseAdapter
    {
        List<Car> items;
        Activity context;

        public CustomAdapter(Activity context, List<Car> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            View view = convertView; // taaskasutame olemasolevat vaadet(View) kui on olemas.
            if (view == null) // kui ei ole loome uue            
                view = context.LayoutInflater.Inflate(Resource.Layout.customrow_layout, null);
            view.FindViewById<TextView>(Resource.Id.kwtextview).Text = items[position].Kw;

                return view;
        }

    }
}