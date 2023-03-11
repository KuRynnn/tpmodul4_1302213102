using System.Security;

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
        /*
        private static void Main(string[] args)
        {
            Console.WriteLine(getKodePos(Kelurahan.Batununggal));
            Console.WriteLine(getKodePos(Kelurahan.Wates));
        }
        */
    }
    public enum state { Terkunci, Terbuka };
    public enum trigger { KunciPintu, BukaPintu };
    class DoorMachine
    {
        public state currentState = state.Terkunci;
        public class Transition
        {
            public state stateAwal;
            public state stateAkhir;
            public trigger trig;

            public Transition(state sAwal, state sAkhir, trigger trigg)
            {
                stateAwal = sAwal;
                stateAkhir = sAkhir;
                trig = trigg;
            }
        }
        Transition[] transisi =
        {
            new Transition(state.Terbuka, state.Terbuka, trigger.BukaPintu),
            new Transition(state.Terbuka, state.Terkunci, trigger.KunciPintu),
            new Transition(state.Terkunci, state.Terkunci, trigger.KunciPintu),
            new Transition(state.Terkunci, state.Terbuka, trigger.BukaPintu)
        };
        private state GetStateBerikutnya(state stateAwal, trigger trigger)
        {
            state stateAkhir = stateAwal;
            for(int i = 0; i < transisi.Length; i++)
            {
                Transition perubahan = transisi[i]; 
                if(stateAwal == perubahan.stateAwal && trigger == perubahan.trig)
                {
                    stateAkhir = perubahan.stateAkhir;
                }
            }
            return stateAkhir;
        }
        public void ActivateTrigger(trigger Trigger)
        {
            currentState = GetStateBerikutnya(currentState, Trigger);
            if(currentState == state.Terkunci)
            {
                Console.WriteLine("Pintu terkunci");
            }else if(currentState == state.Terbuka)
            {
                Console.WriteLine("Pintu tidak terkunci");
            }
        }
        private static void Main(string[] args)
        {
            DoorMachine doorMachine = new DoorMachine();
            Console.WriteLine(doorMachine.currentState);
            Console.WriteLine("Lakukan Trigger Buka Pintu");
            doorMachine.ActivateTrigger(trigger.BukaPintu);
        }
    }
}