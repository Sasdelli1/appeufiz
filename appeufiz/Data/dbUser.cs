using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace appeufiz.Data
{
    public class dbUser
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string dbPath = "eufiz.db";

        public void criar_user( Usuario oUsuario)
        {
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, "Alunos.db")))
                {
                    conexao.Insert(oUsuario);
                }
            }
            catch (SQLiteException)
            {
                throw;
            }
        }

        public void update_user(
            String p_senha)
        { 
            //Comando update        
        }

        public Boolean Logon(string p_login, string p_senha)
        {
            Boolean login = false;
            try
            {
                Database database = new Database();
                Usuario usuario = database.login(p_login, p_senha);
                login = usuario.Status;
                
                if (usuario.Status)
                {
                    login = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return login; 
        }


    }
}
