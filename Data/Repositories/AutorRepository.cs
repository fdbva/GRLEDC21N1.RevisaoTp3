using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Repositories
{
    public class AutorRepository
    {
        private static List<AutorModel> _autores = new()
        {
            new AutorModel
            {
                Id = 1,
                Nome = "Felipe",
                UltimoNome = "Andrade",
                Nacionalidade = "Brasileiro",
                Nascimento = new DateTime(1988, 02 ,23)
            }
        };

        public IEnumerable<AutorModel> GetAll(
            string busca = null)
        {
            if (string.IsNullOrWhiteSpace(busca))
            {
                return _autores;
            }

            return _autores.Where(x => x.Nome.Contains(busca));
        }

        public void Add(AutorModel autorModel)
        {
            _autores.Add(autorModel);
        }

        public AutorModel GetById(int id)
        {
            return _autores.FirstOrDefault(x => x.Id == id);
        }

        public void Update(AutorModel autorModel)
        {
            var autor = GetById(autorModel.Id);

            if (autor == null)
            {
                return;
            }

            autor.Nome = autorModel.Nome;
            autor.UltimoNome = autorModel.UltimoNome;
            autor.Nacionalidade = autorModel.Nacionalidade;
            autor.Nascimento = autorModel.Nascimento;
        }

        public void Remove(int id)
        {
            var autor = GetById(id);

            _autores.Remove(autor);
        }
    }
}
