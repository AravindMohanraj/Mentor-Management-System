using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;


namespace MentorManagementSystem
{
    class connection
    {
        public static void con(string querry)
        {
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\mmsdb.mdb");
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = con1;
        }
    }
}
