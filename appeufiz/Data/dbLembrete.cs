using appeufiz.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace appeufiz.Data
{
    public class dbLembrete
    {

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
        "eufiz.db3");


        public void criar_lembrete(
              String p_id,
              String p_nome
            )
        {


        }

        public void select_lembrete(
            String p_nome)
        { 
            //Select banco
        }

        public void deletar_lembrete(
            String p_nome)
        { 
        
            //Comando delete
        }

        public void update_lembrete(
            String p_id)
        { 
            //Comando update
            
        }
    }
}
