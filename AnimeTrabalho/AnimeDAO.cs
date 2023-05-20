using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AnimeTrabalho
{
	public class AnimeDAO
	{

        public static List<Anime> listarAnimes()
		{
			List<Anime> lista = null;

			using (var ctx = new Db_AnimeEntities())
			{
				lista = ctx.Animes.ToList();
			}
			return lista;
		}

        public static void Adicionar(Anime anime)
        {
            using (var ctx = new Db_AnimeEntities())
            {
                ctx.Animes.Add(anime);
                ctx.SaveChanges();
            }
        }

        public static void Atualizar(Anime anime)
        {
            using (var ctx = new Db_AnimeEntities())
            {
                ctx.Entry(anime).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public static Anime BuscarPorId(int id)
        {
            Anime anime = null;

            using (var ctx = new Db_AnimeEntities())
            {
                anime = ctx.Animes.FirstOrDefault(s => s.id == id);
            }

            return anime;
        }

		public static Anime Excluir(int id)
		{
			Anime anime = null;
			using(var ctx = new Db_AnimeEntities())
			{
				anime = ctx.Animes.FirstOrDefault(
					s => s.id == id);

				if (anime != null)
				{
					ctx.Animes.Remove(anime);
					ctx.SaveChanges();
				}
			}

			return anime;
		}
	}
}
