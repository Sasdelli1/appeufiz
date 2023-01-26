using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Xamarin.Essentials.Permissions;
using System.Xml;
using Xamarin.Essentials;
using appeufiz.Models;

namespace appeufiz.Data
{
    public class Database
    {

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
        "eufiz.db3");


        /// <summary>
        ///  Processo de validacao do usuarios atraves do Login de identificação
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="senha">Senha</param>
        /// <returns>Objeto POC do usuarios carregado com os dados do usuarios com OK e quando 
        /// Nao localizado mensagem que o usuario nao foi identificado e Status = false </returns>
        public Usuario login(string login , string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Status = false;
            usuario.Messagem = "Usuário não Identificado !";

            var connection = new SqliteConnection("Data Source=" + dbPath);
            connection.Open();
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = $" select * from usuario " +
                                       $" where nome_usuario = '{login.ToUpper()}'" +
                                       $" and senha = '{senha}' ";

                var r = contents.ExecuteReader();
                while (r.Read())
                {
                    usuario.NomeUsuario = r["nome_usuario"].ToString();
                    usuario.Status = true;
                    usuario.Messagem = "Usuarios OK!";
                }
            }
            connection.Close();

            return usuario;

        }

        public Lembrete listar(string nome)
        {
            Lembrete listar = new Lembrete();


            var connection = new SqliteConnection("Data Source=" + dbPath);
            connection.Open();
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = $" select * from lembrete " +
                                       $" where nome_lembrete = '{nome}'";

                var r = contents.ExecuteReader();
                while (r.Read())
                {
                    listar.Nome = r["nome_lembrete"].ToString();
                    listar.Id = r["id"].ToString();

                }
            }
            connection.Close();

            return listar;

        }

        public Item listar_locais(string nome, string latitude, string longitude)
        {
            Item listar_locais = new Item();


            var connection = new SqliteConnection("Data Source=" + dbPath);
            connection.Open();
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = $" select * from local " +
                                       $" where nome = '{nome}'" +
                                       $" where latitude = '{latitude}'" +
                                       $" where longitude = '{longitude}'";

                var r = contents.ExecuteReader();
                while (r.Read())
                {
                    listar_locais.Nome = r["nome"].ToString();
                    listar_locais.Latitude = r["latitude"].ToString();
                    listar_locais.Longitude = r["longitude"].ToString();

                }
            }
            connection.Close();

            return listar_locais;

        }






        /// <summary>
        /// Procedimento de manipulacao de dados
        /// </summary>
        /// <param name="Comando">instricao a ser executada no banco dedados</param>/
        public void QueryDatabase(string Comando)
        {
            try
            {
                if (ValidEufiz())
                {
                    try
                    {
                        var connection = new SqliteConnection("Data Source=" + dbPath);
                        connection.Open();
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = Comando;
                            var rowcount = command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
          

        }

        public Boolean ValidEufiz()
        {
            Boolean Valid = false;
            String oMsg = "";

            try
            {

                if (!File.Exists(dbPath))
                {
                    /// Criar o Arquivo 
                    /// 
                    /// 
                    SQLite


                    /// Criar Tabela
                    /// 
                    string CriacaoTabela = create_Tabela(); 
                }
              //  throw new InvalidOperationException($"Ocorreu um erro na base de dados: {oMsg}");

            }
            catch (Exception)
            {

                Valid = false;
            }


            return Valid;
        }

        private string create_Tabela()
        {
            string Msg = String.Empty;
            string sql = String.Empty;

            /// Criando Tabela Lembrete
            try
            {
                 sql = " create table lembrete(                  " +
                          "  id text primary key, " +
                          "  nome_lembrete text not null unique)";
                QueryDatabase(sql);
                Msg = Msg + "Tabela Lembrete criada com sucesso !" + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                Msg = Msg + "Error:"+ ex.Message.ToString() + System.Environment.NewLine ;
            }
            /// Final da criação da tabela Lembrete

            /// Criando Tabela Usuario
            try
            {
                sql = " create table usuario(                  " +
                         "  id text primary key, " +
                         "  nome text not null, " +
                         "  nome_usuario text not null unique, " +
                         "  email text not null unique, " +
                         "  senha text not null, " +
                         "  telefone text not null unique)";
                QueryDatabase(sql);
                Msg = Msg + "Tabela Usuario criada com sucesso !" + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                Msg = Msg + "Error:" + ex.Message.ToString() + System.Environment.NewLine;
            }
            /// Final da criação da tabela Usuario
            
            /// Criando Tabela Local
            try
            {
                sql = " create table local(                  " +
                         "  id text primary key, " +
                         "  nome text not null, " +
                         "  latitude text not null, " +
                         "  longitude text not null, )";

                QueryDatabase(sql);
                Msg = Msg + "Tabela Local criada com sucesso !" + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                Msg = Msg + "Error:" + ex.Message.ToString() + System.Environment.NewLine;
            }
            /// Final da criação da tabela Local

            return Msg; 

        }


    }
}
