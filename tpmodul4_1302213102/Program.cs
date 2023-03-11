internal class Program
{
    class KodePos
    {
        enum Kelurahan
        {
            Batununggal,
            Kujangsari,
            Mengger,
            Wates,
            Cijaura,
            Jatisari,
            Margasari,
            Sekejati,
            Kebonwaru,
            Maleer,
            Samoja
        }
        private static int getKodePos(Kelurahan kelurahan)
        {
            int[] kode = {40266, 40287, 40267, 40256, 40287, 40286,
            40286, 40286, 40272, 40274, 40273};
            return kode[(int)kelurahan];
        }

        private static void Main(string[] args)
        {
            Console.WriteLine(getKodePos(Kelurahan.Batununggal));
            Console.WriteLine(getKodePos(Kelurahan.Wates));
        }
    }
    
}