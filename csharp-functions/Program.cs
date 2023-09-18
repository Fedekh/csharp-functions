using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharpFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mioArray = { 2, 6, 7, 5, 3, 9 };
            //Stampare l’array di numeri fornito a video
            Console.WriteLine($"L'array fornitomi è :");
            StampaArray(mioArray);
            Console.WriteLine("");
            Console.WriteLine($"La somma di tutti gli elementi dell'array di partenza è {sommaElementiArray(mioArray)}");
            Console.WriteLine("");

            Console.WriteLine($"La somma di tutti gli elementi dell array i cui elementi sono quadrati dell'array di partenza è {sommaElementiArray(ElevaArrayAlQuadrato(mioArray))}");


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("PROVIAMO LE FUNZIONI GENERICHE ORA");
            bool correct = false ;
            int number=0;
            while (!correct)
            {
                Console.WriteLine("Inserisci un numero per dare la dimensione dell'array di partenza");
                string numero = Console.ReadLine();
                if (int.TryParse(numero, out number))
                {
                    correct = true;
                }
            }

            int[] NuovoArrayGenerico = new int[number];
            for (int i = 0; i < number; i++)
            {
                NuovoArrayGenerico[i] = new Random().Next(1,80);
            }

            Console.WriteLine($"Ora il nuovo Array che mi hai fornito è di {number} elementi casuali");
            GenericStampaArray(NuovoArrayGenerico);
            Console.WriteLine("");
            Console.WriteLine($"La somma di tutti gli elementi dell'array nuovo di partenza è {GenericSommaElementi(NuovoArrayGenerico)}");
            Console.WriteLine("");
            Console.WriteLine($"La somma di tutti gli elementi dell array i cui elementi sono quadrati dell'array di partenza è {GenericSommaElementi(GenericElevaArrayAlQuadrato(NuovoArrayGenerico))}");
            Console.WriteLine("");







        }

        static void GenericStampaArray<T>(T[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}");
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }

        static void StampaArray(int[] array)
        {
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}");
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }

        static T GenericQuadrato<T>(T valore)
        {
            dynamic n = valore;
            return n * n;

        }
        static int Quadrato(int numero)
        {
            int risultato = numero * numero;
            return risultato;
        }

        static T[] GenericElevaArrayAlQuadrato<T>(T[] array )
        {
            T[] arr = new T[array.Length];
            for(int i = 0;i < array.Length; i++)
            {
                arr[i] = GenericQuadrato(array[i]);
            }
            GenericStampaArray(arr);
            return arr;
        }
        static int[] ElevaArrayAlQuadrato(int[] array) 
        {
        
         int[] arr = new int[array.Length];
          for (int i = 0; i < array.Length; i++)
            {
                arr[i] = Quadrato(array[i]);


            }
            StampaArray(arr);

            return arr;
        }

        static T GenericSommaElementi<T>(T[] array)
        {
            dynamic result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result;

        }

        static int sommaElementiArray(int[] array)
        {
            int result=0;
            for (int i = 0;i < array.Length; i++)
            {
                result += array[i];
            }
            return result;
        }
    }
}


            //Scrivete nel vostro programma principale Program.cs le seguenti funzioni di base:
            //void StampaArray(int[] array): che preso un array di numeri interi, stampa a video il contenuto dell’array in questa forma “[elemento 1, elemento 2, elemento 3, ...]”. Potete prendere quella fatta in classe questa mattina
            //int Quadrato(int numero): che vi restituisca il quadrato del numero passato come parametro.
            //int[] ElevaArrayAlQuadrato(int[] array): che preso un array di numeri interi, restituisca un nuovo array con tutti gli elementi elevati quadrato. Attenzione: è importante restituire un nuovo array, e non modificare l’array come parametro della funzione! Vi ricordate perchè? Pensateci(vedi slide)
            //int sommaElementiArray(int[] array): che preso un array di numeri interi, restituisca la somma totale di tutti gli elementi dell’array.
            //Una volta completate queste funzioni di utilità di base, e dato il seguente array di numeri[2, 6, 7, 5, 3, 9] già dichiarato nel vostro codice, si vogliono utilizzare le funzioni per:
            //Stampare l’array di numeri fornito a video
            //Stampare l’array di numeri fornito a video, dove ogni numero è stato prima elevato al quadrato(Verificare che l’array originale non sia stato modificato quindi ristampare nuovamente l’array originale e verificare che sia rimasto[2, 6, 7, 5, 3, 9])
            //Stampare la somma di tutti i numeri
            //Stampare la somma di tutti i numeri elevati al quadrati
            //BONUS:
            //Convertire le funzioni appena dichiarate in funzioni generiche, ossia funzioni che possono lavorare con array di numeri interi di lunghezza variabile, ossia debbono poter funzionare sia che gli passi array di 5 elementi, sia di 6, di 7, di... e così via.A questo punto modificare il programma in modo che chieda all’utente quanti numeri voglia inserire, e dopo di che questi vengono inseriti a mano dall’utente esternamente.