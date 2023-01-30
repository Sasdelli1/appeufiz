
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Xamarin.Essentials.Permissions;
using System.Xml;
using Xamarin.Essentials;
using appeufiz.Models;
using System.Linq;

namespace appeufiz.Data
{
    public class Database
    {
        string pasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string dbPath = "eufiz.db";

        public const SQLite.SQLiteOpenFlags Flags =
       // open the database in read/write mode
       SQLite.SQLiteOpenFlags.ReadWrite |
       // create the database if it doesn't exist
       SQLite.SQLiteOpenFlags.Create |
       // enable multi-threaded database access
       SQLite.SQLiteOpenFlags.SharedCache;


        /// <summary>
        ///  Processo de validacao do usuarios atraves do Login de identificação
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="senha">Senha</param>
        /// <returns>Objeto POC do usuarios carregado com os dados do usuarios com OK e quando 
        /// Nao localizado mensagem que o usuario nao foi identificado e Status = false </returns>
        public Usuario login(string login, string senha)
        {
            Usuario usuario = new Usuario();
            usuario.Status = false;
            usuario.Messagem = "Usuário não Identificado !";
            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
                {

                    List<Usuario> oLogin = conexao.Table<Usuario>().ToList();

                    //   conexao.Query<Usuario>($" select * from usuario " +
                    //                          $" where nome_usuario = '{login.ToUpper()}'" +
                    //                          $" and senha = '{senha}' ").ToList();

                    foreach (Usuario item in oLogin)
                    {
                        if (item.NomeUsuario.ToUpper() == login.ToUpper())
                        {
                            if (item.Senha.ToUpper() == senha)
                            {
                                usuario = item;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return usuario;

        }

        public Item local(string nome, string longitude, string latitude)
        {
            Item olocal = new Item();

            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
                {

                    List<Item> items = conexao.Table<Item>().ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return olocal;

        }

        public Lembrete lembrete(string nome)
        {
            Lembrete olembrete = new Lembrete();

            try
            {
                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
                {

                    List<Lembrete> lembretes = conexao.Table<Lembrete>().ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }
            return olembrete;

        }





        public Boolean ValidEufiz()
        {
            Boolean Valid = false;
            String oMsg = "";

            try
            {
                if (!File.Exists(System.IO.Path.Combine(pasta, dbPath)))
                {
                    string CriacaoTabela = create_Tabela();
                }
                else
                {
                    Valid = true;
                }
            }
            catch (Exception ex)
            {
                String oex = ex.Message.ToString();
                Valid = false;
            }
            return Valid;
        }

        private string create_Tabela()
        {
            string Msg = String.Empty;
            string sql = String.Empty;


            try
            {

                using (var conexao = new SQLiteConnection(System.IO.Path.Combine(pasta, dbPath)))
                {
                    conexao.CreateTable<Usuario>();
                    Usuario oUser = new Usuario();
                    conexao.CreateTable<Lembrete>();
                    Lembrete oLembrete = new Lembrete();
                    conexao.CreateTable<Item>();
                    Item oitem = new Item();

                }
            }
            catch (Exception ex)
            {
                Msg = Msg + "Error:" + ex.Message.ToString() + System.Environment.NewLine;
            }

            return Msg;

        }

    }
}
