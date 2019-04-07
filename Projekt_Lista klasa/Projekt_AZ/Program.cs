using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Projekt_AZ
{
    class Program        
    {
    
        static Double srednia(String oceny)
            //Oceny całkowite przechowywane w stringu
        {
            Double licz=0, sum=0;
            for(int i=0;i<oceny.Length;i++)
            {
                if (oceny[i] == '1') { licz++; sum += 1; }
                if (oceny[i] == '2') { licz++; sum += 2; }
                if (oceny[i] == '3') { licz++; sum += 3; }
                if (oceny[i] == '4') { licz++; sum += 4; }
                if (oceny[i] == '5') { licz++; sum += 5; }
                if (oceny[i] == '6') { licz++; sum += 6; }
                if (oceny[i] == '7') { licz++; sum += 7; }
                if (oceny[i] == '8') { licz++; sum += 8; }
                if (oceny[i] == '9') { licz++; sum += 9; }
                             
            } 
            if (licz == 0) return 0;
            else return (sum / licz);
        }


        static Double frekwencja(String frek)
        // Dozwolone znaki to '+' obecnosc 'N' nieobecnosc '-' jeszcze nie było
        // Pozostale znaki beda pomijane
        {
            Double plusy = 0, enki = 0, minusy = 0;
            for (int i = 0; i < frek.Length; i++)
            {
                if (frek[i] == '+') plusy++;    // obecnosc
                if (frek[i] == 'N') enki++;     // nieobecnosc
                if (frek[i] == '-') minusy++;   // zajecia jeszcze nieodbyte
            }
            if ((plusy + enki) != 0) return (plusy * 100 / (plusy + enki));
            else return 0;            
        }


        
        static void Main(string[] args)
        {


            char ch;
            string s,s1,s2,s3;
            string path = "Lista.txt";
            string[] lista = null;          // tablica studentów
            int n = 0;                      // rozmiar tablicy, ilośc studentów
            int nr = 0;                     // nr w dzienniku oktywnej osoby

            if (File.Exists(path))
            {
                lista = File.ReadAllLines(path);
                n = lista.Length;
            }

            Console.BackgroundColor = ConsoleColor.DarkBlue ;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("witamy w programie LISTA STUDENTOW\nautor funkcji dodatkowych Mateusz Wojciechowski");
            Console.ResetColor();
            
            do
            {
                Console.WriteLine(" Nacisnij:\n"+
                " a. Aby wypisac dane zrodlowe\n b. Aby dodac osobe \n c. Aby wyszukac\n"+
                " d. Aby wypisac osoby wierszami \n e. Aby uzupelnic oceny\n f. Aby uzupelnic frekwencje\n" +
                " g. Aby wypisac osoby wierszami zaawansowane\n h. Aby sortowac alfabetycznie\n i. Aby sortowac po sredniej\n" +
                "\n k. Aby zakonczyc program\n");
                ch = Console.ReadKey(true).KeyChar;

                //przetwarzanie polecenia użytkownika
                switch (ch)
                {
                    
                    case 'a':   // wypisz dane zrodlowe linia po linii
                    case 'A':
                        if (lista != null)
                            for (int i = 0; i < n; i++)
                                Console.WriteLine(lista[i]);
                        else Console.WriteLine("lista jest pusta");
                        Console.WriteLine();

                        break;
                    case 'b':   // dodaj osobe na koniec listy
                    case 'B':
                         Console.WriteLine("\npodaj Nazwisko Imie");
                        s1 = Console.ReadLine();
                        Console.WriteLine("\npodaj w jednej lini Oceny:"+
                        "\n (tylko liczby calkowite).\n Po wpisaniu wszystkich ocen nacisnij ENTER. ");
                        s2 = Console.ReadLine();
                        Console.WriteLine("\npodaj w jednej lini obecnosci:\n '+' obecnosc, 'N' nieobecność");
                        s3 = Console.ReadLine();

                        if (n == 0)
                        {
                            lista = new string[3];
                        }
                        else
                        {
                            string[] tmp = new string[n + 3];
                            for (int i = 0; i < n; i++)
                                tmp[i] = lista[i];
                            lista = tmp;
                        }
                        lista[n] = s1;
                        n = n + 1;
                        lista[n] = s2;
                        n = n + 1;
                        lista[n] = s3;
                        n = n + 1;

                        break;
                    case 'c':
                    case 'C':
                        Console.WriteLine("podaj nazwisko do wyszukania");
                        s = Console.ReadLine();
                        bool b = true;
                        if (lista != null)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                if (s == lista[i])
                                {
                                    Console.WriteLine("znaleziono na pozycji " + i + " - " + lista[i] + " ma w dzienniku nr " + i / 3 + ".");
                                    Console.WriteLine("Oceny:      " + lista[i + 1] + " Srednia ocen: " + srednia(lista[i + 1]));
                                    Console.WriteLine("Obecnosci: " + lista[i + 2] + " Frekfencja:    " + frekwencja(lista[i + 2]));
                                    b = false;
                                }
                            }
                            if (b) Console.WriteLine("nie znaleziono");
                        }
                        else Console.WriteLine("lista jest pusta");
                        Console.WriteLine();

                        break;

                    case 'd':// Wypisz osoby wierszami 1
                    case 'D':
                        Console.WriteLine("\t\t\t\t\t\t\t" + "obecnosci" + "\r\t\t\t\t" + "oceny" + "\r" + "Lp.\tNazwisko i Imie");
                        if (lista != null)
                            for (int i = 0; i < n; i += 3)
                            {
                                Console.WriteLine("\t\t\t\t\t\t\t" + lista[i + 2] + "\r\t\t\t\t" + lista[i + 1] + "\r" + i / 3 + ".\t" + lista[i]);
                            }
                        else Console.WriteLine("lista jest pusta");
                        Console.WriteLine();

                        break;
                    case 'e': // zmien oceny
                    case 'E':
                        Console.WriteLine("\r\t\t\t\t" + "oceny" + "\r" + "Lp.\tNazwisko i Imie");
                        if (lista != null)
                        {
                            for (int i = 0; i < n; i += 3)
                            {
                                Console.WriteLine("\r\t\t\t\t" + lista[i + 1] + "\r" + i / 3 + ".\t" + lista[i]);
                            }

                            Console.Write("Podaj nr osoby, ktorej oceny chcesz edytowac:");
                            nr = Convert.ToInt32(Console.ReadLine());
                                                      
                            Console.WriteLine( nr + ".\t" + lista[nr * 3]);
                            Console.Write(lista[nr * 3 + 1] + "\r");
                            s = Console.ReadLine();
                            lista[nr * 3 + 1] = s;
                        }
                        else Console.WriteLine("lista jest pusta");
                        Console.WriteLine();

                      break;
                    case 'f': // zmien obecnosci
                    case 'F':
                      Console.WriteLine("\r\t\t\t\t" + "obecnosci" + "\r" + "Lp.\tNazwisko i Imie");
                        if (lista != null)
                        {
                            for (int i = 0; i < n; i += 3)
                            {
                                Console.WriteLine("\r\t\t\t\t" + lista[i + 2] + "\r" + i / 3 + ".\t" + lista[i]);
                            }

                            Console.Write("Podaj nr osoby, ktorej obecnosci chcesz edytowac:");
                            nr = Convert.ToInt32(Console.ReadLine());
                          
                            Console.WriteLine( nr + ".\t" + lista[nr * 3]);
                            Console.Write(lista[nr * 3 + 2] + "\r");
                            s = Console.ReadLine();
                            lista[nr * 3 + 2] = s;
                        }
                        else Console.WriteLine("lista jest pusta");
                        Console.WriteLine();

                      break;
                    case 'g': //wypisz osoby wierszami 2
                    case 'G':
                      Console.WriteLine("\t\t\t\t\t\t\t" + "frekwencja w %" + "\r\t\t\t\t" + "srednia ocen" + "\r" + "Lp.\tNazwisko i Imie");
                        if (lista != null)
                            for (int i = 0; i < n; i += 3)
                            {
                                Console.WriteLine("\t\t\t\t\t\t\t" + frekwencja(lista[i + 2]).ToString("F0") + "\r\t\t\t\t" + srednia(lista[i + 1]).ToString("F2") + "\r" + i / 3 + ".\t" + lista[i]);
                            }
                        else Console.WriteLine("lista jest pusta");
                        Console.WriteLine();


                      break;
                    case 'h': //sortowanie alfabetyczne
                    case 'H':
                        if (n < 3)
                        {
                            Console.WriteLine("lista powinna zawierac conajmniej dwa elementy");
                        }
                        else
                        {
                            for (int i = 0; i < n-3; i += 3)
                                for (int j = 0; j < n-3; j += 3)
                                {
                                    if (String.Compare(lista[j],lista[j+3])==1)  //zamiana
                                    {
                                        s1 = lista[j];
                                        s2 = lista[j + 1];
                                        s3 = lista[j + 2];

                                        lista[j] = lista[j + 3];
                                        lista[j + 1] = lista[j + 4];
                                        lista[j + 2] = lista[j + 5];

                                        lista[j + 3] = s1;
                                        lista[j + 4] = s2;
                                        lista[j + 5] = s3;

                                    }
                                }
                        }

                      break;
                    case 'i': //sortowanie po sredniej
                    case 'I':
                      if (n < 3)
                      {
                          Console.WriteLine("lista powinna zawierac conajmniej dwa elementy");
                      }
                      else
                      {
                          for (int i = 0; i < n - 3; i += 3)
                              for (int j = 0; j < n - 3; j += 3)
                              {
                                  if (srednia(lista[j+1]) < srednia(lista[j + 4]))   //zamiana
                                  {
                                      s1 = lista[j];
                                      s2 = lista[j + 1];
                                      s3 = lista[j + 2];

                                      lista[j] = lista[j + 3];
                                      lista[j + 1] = lista[j + 4];
                                      lista[j + 2] = lista[j + 5];

                                      lista[j + 3] = s1;
                                      lista[j + 4] = s2;
                                      lista[j + 5] = s3;

                                  }
                              }

                      }

                      break;
                        



                     

                }
            }
            while (!(ch == 'k' || ch == 'K'));

            File.WriteAllLines(path, lista);



        }
    }
}
