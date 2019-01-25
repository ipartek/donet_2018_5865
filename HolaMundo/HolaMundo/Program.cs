using con = System.Console;

namespace HolaMundo
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre = con.ReadLine();
            con.WriteLine("Hola {0}", nombre);

            con.WriteLine(long.MaxValue);

            //TIPOS VALOR
            //son structs 0 a 2^tamañoenbits 
            //(-2^(tamañoenbits-1)) a (2^(tamañoenbits-1))-1
            
            //ENTEROS
            //byte=System.Byte (8) sbyte=System.SByte
            //short=System.Int16 (16) ushort=System.UInt16
            //int=System.Int32 (32) uint=System.UInt32
            //long=System.Int64 (64) ulong=System.UInt64
            
            //COMA FLOTANTE
            //float=System.Single (32), double=System.Double (64)
            
            //decimal=System.Decimal (128)

            //char (16)
            //bool (16)
        }
    }
}
