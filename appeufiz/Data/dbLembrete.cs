using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace appeufiz.Data
{
    public class dbLembrete
    {

        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string dbPath = "eufiz.db";


        public void criar_lembrete(Lembrete olembrete)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Alunos.db")))
                {
                    conexao.Insert(olembrete);
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
    }

}
