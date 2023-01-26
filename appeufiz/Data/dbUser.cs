using appeufiz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace appeufiz.Data
{
    public class dbUser
    {

        public void criar_user(        
              String p_nome 
            , String p_nome_usuario 
            , String p_email 
            , String p_senha 
            , String p_telefone 
            )
        { 
        
            //// comando insert
        
        
        }

        public Boolean Logon(string p_login, string p_senha)
        {
            Boolean login = false;
            try
            {
                Database database = new Database();
                Usuario usuario = database.login(p_login, p_senha);
                login = usuario.Status;
                
                if (!usuario.Status)
                {
                    throw new InvalidOperationException(usuario.Messagem);
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
