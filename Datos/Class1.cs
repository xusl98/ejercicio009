using System;

namespace Datos
{
    public class Raiz
    {
        public int ID { get; set; }
        public Class2 otro { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Raiz raiz &&
                   ID == raiz.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }

    public class Class2 {
        public Class3 tercero { get; set; }
    }

    public class Class3
    {

    }

}
