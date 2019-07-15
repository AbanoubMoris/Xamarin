using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MicroBus
{
    public interface pop
    {
        SQLiteConnection GetConnection();
        bool save(UserData d);

        bool update(UserData d);
        List<UserData> getdata();
        
    }
}
