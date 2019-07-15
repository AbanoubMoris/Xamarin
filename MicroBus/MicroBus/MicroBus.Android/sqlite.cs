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
using SQLite;
using MicroBus.Droid;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(sqlite))]

namespace MicroBus.Droid
{
   public class sqlite : pop
    {
        public SQLiteConnection con;
        public SQLiteConnection GetConnection()
        {
            var dbname = "Login.db3";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(dbpath, dbname);
            con = new SQLiteConnection(path);
            return con;
        }

        public List<UserData> getdata()
        {
            string sql = "select * from Login";
            List<UserData> d = null;
            try
            {

               d =con.Query<UserData>(sql);
            }
            catch (Exception)
            {

            }
            return d;
        }

        public bool save(UserData d)
        {
            bool res = false;
            try{
                con.Insert(d);
                res = true;
            }
            catch (Exception)
            {
               res = false;
            }
            return res;
        }

        public bool update(UserData d)
        {
           con.Update(d);
           return true;
        }
    }
}