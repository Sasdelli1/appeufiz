using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace appeufiz.Data
{
    public class dbLembrete
    {

        public void criar_lembrete(
              String p_id,
              String p_nome
            )
        {
            int Criado;

            //// comando insert
            try
            {

                
                var connection = new SqliteConnection("Data Source=" + dbPath);
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO lembrete (nome, id)" +
                                                $" VALUES('{p_nome}', '{p_id}')", connection);
                Criado = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            return; 

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
