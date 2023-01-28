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
        public void select_local(
            String p_id, 
            String p_nome,
            String p_longitude,
            String p_latitude)
        { 
            //Select banco
        }


        public void delete_local(
            String p_id,
            String p_nome,
            String p_longitude,
            String p_latitude)
        {
            //Delete locais
        }  
    }
}
