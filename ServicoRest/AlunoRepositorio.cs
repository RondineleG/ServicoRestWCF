using System.Collections.Generic;
using System.Linq;

namespace ServicoRest
{
    public class AlunoRepositorio
    {

        public void Inserir(AlunoModelo alunoModelo)
        {


            ServicoRestDbContext context = new ServicoRestDbContext();

           Alunos aluno = new Alunos();


            aluno.Id = alunoModelo.id;
            aluno.nome = alunoModelo.nome;
            aluno.sobrenome = alunoModelo.sobrenome;
            aluno.telefone = alunoModelo.telefone;
            aluno.ra = alunoModelo.ra;

            context.Alunos.Add(aluno);
            context.SaveChanges();
        }

        public void Atualizar(AlunoModelo alunoModelo)
        {

            using (ServicoRestDbContext context = new ServicoRestDbContext())
            {

                Alunos aluno = context.Alunos.Where(n => n.Id == alunoModelo.id).First();


                aluno.Id = alunoModelo.id;
                aluno.nome = alunoModelo.nome;
                aluno.sobrenome = alunoModelo.sobrenome;
                aluno.telefone = alunoModelo.telefone;
                aluno.ra = alunoModelo.ra;

                context.SaveChanges();
            }

        }

        public void Deletar(int id)
        {

            ServicoRestDbContext context = new ServicoRestDbContext();


            Alunos aluno = (from n in context.Alunos
                                   where n.Id == id
                                   select n).First();

            context.Alunos.Remove(aluno);
            context.SaveChanges();

        }

        public AlunoModelo ListarAlunoID(int id)
        {

            ServicoRestDbContext context = new ServicoRestDbContext();

            AlunoModelo alunoModelo = new AlunoModelo();

            Alunos aluno = (from n in context.Alunos
                                   where n.Id == id
                                   select n).First();


            alunoModelo.id = aluno.Id;
            alunoModelo.nome = aluno.nome;
            alunoModelo.sobrenome = aluno.sobrenome;
            alunoModelo.telefone = aluno.telefone;
            alunoModelo.ra = aluno.ra;
             

            return alunoModelo;
        }

        public IList<AlunoModelo> ListarAluno()
        {
            ServicoRestDbContext context = new ServicoRestDbContext();

            IList<AlunoModelo> listaAlunosModelo = new List<AlunoModelo>();

            IList<Alunos> listaAlunos = (from n in context.Alunos
                                           select n).ToList();

            AlunoModelo alunoModelo = null;

            foreach (Alunos aluno in listaAlunos)
            {

                alunoModelo = new AlunoModelo();

                alunoModelo.id = aluno.Id;
                alunoModelo.nome = aluno.nome;
                alunoModelo.sobrenome = aluno.sobrenome;
                alunoModelo.telefone = aluno.telefone;
                alunoModelo.ra = aluno.ra;

                listaAlunosModelo.Add(alunoModelo);
            }

                        
            return listaAlunosModelo;
        }

    }
}
