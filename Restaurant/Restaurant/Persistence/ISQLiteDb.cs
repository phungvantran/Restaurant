using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Restaurant.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
