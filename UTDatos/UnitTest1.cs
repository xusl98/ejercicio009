using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTDatos
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Raiz r = new Raiz();
            r.otro = new Class2();
            r.otro.tercero = new Class3();

            Assert.IsNotNull(r);
            Assert.IsNotNull(r.otro);
            Assert.IsNotNull(r.otro.tercero);
        }

        [TestMethod]
        public void TestListVarios()
        {
            IList<string> listaDeEjemplo = new List<string>();
            IList otraLista = new List<object>();

            otraLista.Add("Hola");
            otraLista.Add(new Raiz());

            object a = "Hola";
            a = new Raiz();
            string hola = (string) a;

            listaDeEjemplo.Add(" Mensaje ");

            string todos = "";
            for (int i = 0; i < listaDeEjemplo.Count; i++)
            {
                string mensajes = listaDeEjemplo[i];
                todos += mensajes;
            }

            todos = "";
            foreach (string mensajes in listaDeEjemplo)
            {
                todos += mensajes;
            }

            string primero = listaDeEjemplo
                .Select(x => x.Trim())
                .Where(x => x.StartsWith("Mensaje"))
                .First();
               
        }

        [TestMethod]
        public void TestSet()
        {
            ISet<string> miConjunto = new HashSet<string>();
            miConjunto.Add("Mensaje");

            Assert.IsTrue(miConjunto.Contains("Mensaje"));

            ISet<Raiz> miConjunto2 = new HashSet<Raiz>();
            

            Raiz raiz1 = new Raiz() { ID = 5 };
            Raiz raiz2 = new Raiz() { ID = 5, otro = new Class2() };

            miConjunto2.Add(raiz1);

            Assert.IsTrue(miConjunto2.Contains(raiz2));


            //DISTINTAS FORMAS DE RECORRER UN SET Y SUMAR EL ID

            //1
            int total = 0;
            foreach (Raiz r in miConjunto2)
            {
                total += r.ID;
            }

            //2
            IEnumerator<Raiz> enumeracion = miConjunto2.GetEnumerator();

            int total2 = 0;
            while (enumeracion.MoveNext())
            {
                Raiz r = enumeracion.Current;
                total2 += r.ID;
            }

            Assert.AreEqual(total, total2);

            //3
            int total3 = miConjunto2
                            .Select(r => r.ID).Sum();

            Assert.AreEqual(total, total3);


            //Ejercicio
            IDictionary<string, string> diccionario = new Dictionary<string, string>();


            for (int i = 0; i < 5; i++)
            {
                diccionario.Add("clave" + i, "valor" + i);
            }

            ICollection<string> claves = diccionario.Keys;

            string concatenado = String.Join("", claves);


            Assert.AreEqual(concatenado, "clave0clave1clave2clave3clave4");


        }
    }
}
