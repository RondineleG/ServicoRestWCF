using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ServicoRest
{

    public class ServiceAluno : IServiceAluno
    {


        AlunoRepositorio alunoRepositorio = new AlunoRepositorio();

        public string Atualizar(AlunoModelo alunoModelo)
        {
            try
            {
                alunoRepositorio.Atualizar(alunoModelo);

                return "Registro atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro ao atualizar o registro: " + ex.Message;
            }

        }

        public AlunoModelo RecuperarPorId(string id)
        {
            return alunoRepositorio.ListarAlunoID(Convert.ToInt32(id));
        }

        public IList<AlunoModelo> Recuperar()
        {
            return alunoRepositorio.ListarAluno();
        }

        public string Deletar(string id)
        {
            try
            {
                alunoRepositorio.Deletar(Convert.ToInt32(id));

                return "Registro excluido com sucesso!";
            }
            catch (Exception ex)
            {
                return "Erro ao excluir o registro: " + ex.Message;
            }
        }

        public string Inserir(AlunoModelo alunoModelo)
        {
            try
            {
                alunoRepositorio.Inserir(alunoModelo);

                return "Registro inserido com sucesso!";

            }
            catch (Exception ex)
            {
                return "Erro ao inserir o registro: " + ex.Message;
            }
        }

        public string InsertViaSql(AlunoModelo alunoModelo)
        {
            string Message;
            SqlConnection sqlConnection = new SqlConnection("data source=den1.mssql8.gear.host;initial catalog=pdadb;persist security info=True;user id=pdadb;password=Gw6Q_c?VZ9zF");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into Alunos(nome,sobrenome,telefone,ra) " +
                "                           values(@nome,@sobrenome,@telefone,@ra)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@nome", alunoModelo.nome);
            sqlCommand.Parameters.AddWithValue("@sobrenome", alunoModelo.sobrenome);
            sqlCommand.Parameters.AddWithValue("@telefone", alunoModelo.telefone);
            sqlCommand.Parameters.AddWithValue("@ra", alunoModelo.ra);
            int result = sqlCommand.ExecuteNonQuery();
            if (result == 1)
            {
                Message = alunoModelo.nome + " Details inserted successfully";
            }
            else
            {
                Message = alunoModelo.nome + " Details not inserted successfully";
            }
            sqlConnection.Close();
            return Message;
        }

        public DataSet SelectViaSql()
        {
            SqlConnection sqlConnection = new SqlConnection("data source=den1.mssql8.gear.host;initial catalog=pdadb;persist security info=True;user id=pdadb;password=Gw6Q_c?VZ9zF");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("ListarAluno * from Alunos", sqlConnection);
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sda.Fill(dataSet);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return dataSet;
        }

        
    }
}
