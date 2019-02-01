using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Tipos
{
    //Genéricos
    //Podemos crear un grupo así: 
    //Grupo<Usuario> grupo = new Grupo<Usuario>();
    public class Grupo<TComponente>
    {
        private List<TComponente> componentes = new List<TComponente>();

        public string Nombre { get; set; }

        public Grupo(string nombre)
        {
            Nombre = nombre;
        }

        public void Add(TComponente componente)
        {
            if (componente == null)
            {
                throw new Exception("No se admiten componentes nulos");
            }

            componentes.Add(componente);
        }

        public TComponente Find(Predicate<TComponente> delegadoDeBusqueda)
        {
            TComponente encontrado = componentes.Find(delegadoDeBusqueda);

            if (encontrado == null || Attribute.IsDefined(encontrado.GetType(), typeof(OcultoParaBusquedasAttribute)))
            {
                return default(TComponente);
            }

            return encontrado;
        }

        /*
        public Usuario FindByEmail(string email)
        {
            //Expresión Lambda
            return componentes.Find(u => u.Email == email);
        }
        */

        public void Remove(TComponente componente)
        {
            if (componente == null)
            {
                throw new Exception("No se admiten componentes nulos");
            }

            componentes.Remove(componente);
        }

        private ReadOnlyCollection<TComponente> GetComponentes()
        {
            return new ReadOnlyCollection<TComponente>(componentes);
        }

        public ReadOnlyCollection<TComponente> Componentes
        {
            get { return GetComponentes(); }
        }

        //Indizador / Indexador
        public TComponente this[int i]
        {
            get { return componentes[i]; }
            set { componentes[i] = value; }
        }

        public TComponente this[Predicate<TComponente> funcionDeBusqueda]
        {
            get { return Find(funcionDeBusqueda); }
            set
            {
                componentes[componentes.IndexOf(Find(funcionDeBusqueda))] = value;
            }
        }
    }
}
