using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace appeufiz.Data
{
    public class dbLocal
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string dbPath = "eufiz.db";

        public void criar_local(Item olocal)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Alunos.db")))
                {
                    conexao.Insert(olocal);
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
    }
}
