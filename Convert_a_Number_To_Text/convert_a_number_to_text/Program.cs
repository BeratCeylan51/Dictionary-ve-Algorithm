using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_a_number_to_text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cevap = "tr";
            char devam = 'e';
            int menu = 1;
            int sayac = 0;

            do
            {
                sayac++;
                if (menu == 1)
                    cevap = ekran(sayac);
                if (menu == 2 || menu == 1)
                {
                    sayiGirisi(cevap);
                    System.Threading.Thread.Sleep(2000);
                }
                Console.WriteLine("\nDevam Etmek İstiyor musunuz[e/h] ?");
                devam = char.Parse(Console.ReadLine());

                if (devam == 'e')
                {
                    Console.Clear();
                    Console.WriteLine("1 --- Dil Seçimi");
                    Console.WriteLine("2 --- Sayı Seçimi");

                    menu = int.Parse(Console.ReadLine());
                } 
            } while (devam == 'e' || devam == 'E');

            Console.WriteLine("Program Bitti. \nProgram 3 saniye sonra Kapanacak Lütfen Bekleyiniz\n\t Güle Gülee :)");
            System.Threading.Thread.Sleep(3000);
        }

        static void sayiGirisi(string cevap)
        {
            string girilenDeger;
            int kontrol = 0, sayac = 0;
            int sayi = 0;

            Console.Write("Lütfen Bir Sayi Giriniz : ");
            girilenDeger = Console.ReadLine();
            Console.WriteLine();

            if (sayiKontrol(girilenDeger))
            {
                //Console.OutputEncoding = Encoding.UTF8;
                sayi = int.Parse(girilenDeger);
                if (sayi == -2147483648)
                {
                    if (cevap == "tr" || cevap == "Türkçe")
                        Console.Write("eksi iki milyar ");
                    else if (cevap == "en" || cevap == "İngilizce")
                        Console.Write("negative two billion ");
                    else if (cevap == "ru" || cevap == "Rusça")
                    {
                        Console.OutputEncoding = Encoding.UTF8;
                        Console.Write("минус два миллиарда ");
                    }    
                    else if (cevap == "az" || cevap == "Azerice")
                        Console.Write("minus iki milyard ");
                    sayi = 147483648;
                }
                if (sayi < 0)
                {
                    if (cevap == "tr" || cevap == "Türkçe")
                        Console.Write("eksi ");
                    else if (cevap == "en" || cevap == "İngilizce")
                        Console.Write("negative ");
                    else if (cevap == "ru" || cevap == "Rusça")
                    {
                        Console.OutputEncoding = Encoding.UTF8;
                        Console.Write("минус ");
                    }
                    else if (cevap == "az" || cevap == "Azerice")
                        Console.Write("minus ");
                    Console.Write("eksi ");
                    sayi *= -1;
                }    
            }
            else
                Console.WriteLine("Sayisal Bir Değer Girmediniz");

            Write(sayi, cevap, kontrol, sayac);
            Console.WriteLine();
        }

        static string ekran(int sayac)
        {
            string cevap = "Türkçe";

            if (sayac < 2)
            {
                Console.WriteLine("\t\t\t\t !!! UYARI !!!");
                Console.WriteLine("\tİstediğiniz dili yazarken lütfen belirtilen şekilde yazınız.");
                System.Threading.Thread.Sleep(4000);
                Console.WriteLine("\nBelirtilen formatta veya bulunmayan bir dili yazarsanız default olarak Türkçe Karşılığı Gelecektir");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Örnek Kullanım");
                Console.WriteLine("Sayıların Hangi Dilde Karşılığını İstiyorsunuz : tr" + "\n" + " veya ");
                Console.WriteLine("Sayıların Hangi Dilde Karşılığını İstiyorsunuz : Türkçe");
                System.Threading.Thread.Sleep(4000);
            }
            Console.Clear();
            Console.WriteLine("Türkçe - tr \nAzerice - az\nİngilizce - en\nRusça - ru");
            Console.Write("Sayıların Hangi Dilde Karşılığını İstiyorsunuz : ");
            cevap = Console.ReadLine();

            return (cevap);
        }

        static bool sayiKontrol(string girilenDeger)
        {
            int i;

            i = 0;
            while (girilenDeger.Substring(0, 1) == "-" || girilenDeger.Substring(0, 1) == "+")
            {
                i++;
                if (girilenDeger.Length > 10)
                    girilenDeger = girilenDeger.Remove(0, 1);
                break;
            }

            while (i < girilenDeger.Length)
            {  
                if (!char.IsDigit(girilenDeger[i]))
                    return (false);
                i++;
            }
            return (true);
        }

        static int getDec(int nb)
        {
            if (nb >= 90)
                return (90);
            else if (nb >= 80)
                return (80);
            else if (nb >= 70)
                return (70);
            else if (nb >= 60)
                return (60);
            else if (nb >= 50)
                return (50);
            else if (nb >= 40)
                return (40);
            else if (nb >= 30)
                return (30);
            else if (nb >= 20)
                return (20);
            else if (nb <= 20)
                return (nb);
            else
                return (0);
        }

        static int getMult(int nb)
        {
            if (nb >= 1000000000)
                return (1000000000);
            else if (nb >= 1000000)
                return (1000000);
            else if (nb >= 1000)
                return (1000);
            else if (nb >= 100)
                return (100);
            else
                return (getDec(nb));
        }

        static void Write(int nb, string cevap, int kontrol, int sayac)
        {
            int mult;

            mult = getMult(nb);

            if (mult >= 100)
            {   
                if (mult <= 1000)
                    kontrol = nb / mult;
                if (kontrol == 1)
                    sayac++;
                Write(nb / mult, cevap, kontrol, sayac);
                kontrol = 0;
                sayac += 2;
            }

            if (kontrol != 1 && sayac != 1)
            {
                if (cevap == "Azerice" || cevap == "az")
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.Write(azericeSayilar(mult));
                } 
                else if (cevap == "İngilizce" || cevap == "en")
                    Console.Write(ingilizceSayilar(mult));
                else if (cevap == "Rusça" || cevap == "ru")
                {
                    Console.OutputEncoding = Encoding.UTF8; // Rusça Karakterleri Yazdırmak için
                    Console.Write(ruscaSayilar(mult));
                }     
                else 
                    Console.Write(turkceSayilar(mult));
                Console.Write(" ");
            }
            if (mult != 0 && nb % mult != 0)
                Write(nb % mult, cevap, kontrol, sayac);
        }

        static string turkceSayilar(int index)
        {
            Dictionary<int, string> metinselIfadeler = new Dictionary<int, string>();

            metinselIfadeler.Add(0, "sıfır");
            metinselIfadeler.Add(1, "bir");
            metinselIfadeler.Add(2, "iki");
            metinselIfadeler.Add(3, "üç");
            metinselIfadeler.Add(4, "dört");
            metinselIfadeler.Add(5, "beş");
            metinselIfadeler.Add(6, "altı");
            metinselIfadeler.Add(7, "yedi");
            metinselIfadeler.Add(8, "sekiz");
            metinselIfadeler.Add(9, "dokuz");
            metinselIfadeler.Add(10, "on");
            metinselIfadeler.Add(11, "on bir");
            metinselIfadeler.Add(12, "on iki");
            metinselIfadeler.Add(13, "on üç");
            metinselIfadeler.Add(14, "on dört");
            metinselIfadeler.Add(15, "on beş");
            metinselIfadeler.Add(16, "on altı");
            metinselIfadeler.Add(17, "on yedi");
            metinselIfadeler.Add(18, "on sekiz");
            metinselIfadeler.Add(19, "on dokuz");
            metinselIfadeler.Add(20, "yirmi");
            metinselIfadeler.Add(30, "otuz");
            metinselIfadeler.Add(40, "kırk");
            metinselIfadeler.Add(50, "elli");
            metinselIfadeler.Add(60, "altmış");
            metinselIfadeler.Add(70, "yetmiş");
            metinselIfadeler.Add(80, "seksen");
            metinselIfadeler.Add(90, "doksan");
            metinselIfadeler.Add(100, "yüz");
            metinselIfadeler.Add(1000, "bin");
            metinselIfadeler.Add(1000000, "milyon");
            metinselIfadeler.Add(1000000000, "milyar");

            return (metinselIfadeler[index]);
        }

        static string ruscaSayilar(int index)
        {
            Dictionary<int, string> metinselIfadeler = new Dictionary<int, string>();

            metinselIfadeler.Add(0, "нуль");
            metinselIfadeler.Add(1, "один");
            metinselIfadeler.Add(2, "два");
            metinselIfadeler.Add(3, "три");
            metinselIfadeler.Add(4, "четыре");
            metinselIfadeler.Add(5, "пять");
            metinselIfadeler.Add(6, "шест");
            metinselIfadeler.Add(7, "семь");
            metinselIfadeler.Add(8, "восемь");
            metinselIfadeler.Add(9, "девять");
            metinselIfadeler.Add(10, "десять");
            metinselIfadeler.Add(11, "одиннадцать");
            metinselIfadeler.Add(12, "двенадцать");
            metinselIfadeler.Add(13, "тринадцать");
            metinselIfadeler.Add(14, "четырнадцать");
            metinselIfadeler.Add(15, "пятнадцать");
            metinselIfadeler.Add(16, "шестнадцать");
            metinselIfadeler.Add(17, "семнадцать");
            metinselIfadeler.Add(18, "восемнадцать");
            metinselIfadeler.Add(19, "девятнадцать");
            metinselIfadeler.Add(20, "двадцать");
            metinselIfadeler.Add(30, "тридцать");
            metinselIfadeler.Add(40, "сорок");
            metinselIfadeler.Add(50, "пятьдесят");
            metinselIfadeler.Add(60, "шестьдесят");
            metinselIfadeler.Add(70, "семьдесят");
            metinselIfadeler.Add(80, "восемьдесят");
            metinselIfadeler.Add(90, "девяносто");
            metinselIfadeler.Add(100, "сто");
            metinselIfadeler.Add(1000, "тысяча");
            metinselIfadeler.Add(1000000, "миллион");
            metinselIfadeler.Add(1000000000, "миллиард");

            return (metinselIfadeler[index]);
        }

        static string ingilizceSayilar(int index)
        {
            Dictionary<int, string> metinselIfadeler = new Dictionary<int, string>();

            metinselIfadeler.Add(0, "zero");
            metinselIfadeler.Add(1, "one");
            metinselIfadeler.Add(2, "two");
            metinselIfadeler.Add(3, "three");
            metinselIfadeler.Add(4, "four");
            metinselIfadeler.Add(5, "fife");
            metinselIfadeler.Add(6, "six");
            metinselIfadeler.Add(7, "seven");
            metinselIfadeler.Add(8, "eight");
            metinselIfadeler.Add(9, "nine");
            metinselIfadeler.Add(10, "ten");
            metinselIfadeler.Add(11, "eleven");
            metinselIfadeler.Add(12, "twelve");
            metinselIfadeler.Add(13, "thirteen");
            metinselIfadeler.Add(14, "fourteen");
            metinselIfadeler.Add(15, "fifteen");
            metinselIfadeler.Add(16, "sixteen");
            metinselIfadeler.Add(17, "seventeen");
            metinselIfadeler.Add(18, "eighteen");
            metinselIfadeler.Add(19, "nineteen");
            metinselIfadeler.Add(20, "twenty");
            metinselIfadeler.Add(30, "thirty");
            metinselIfadeler.Add(40, "forty");
            metinselIfadeler.Add(50, "fifty");
            metinselIfadeler.Add(60, "sixty");
            metinselIfadeler.Add(70, "seventy");
            metinselIfadeler.Add(80, "eighty");
            metinselIfadeler.Add(90, "ninty");
            metinselIfadeler.Add(100, "hundred");
            metinselIfadeler.Add(1000, "thousand");
            metinselIfadeler.Add(1000000, "million");
            metinselIfadeler.Add(1000000000, "billion");

            return (metinselIfadeler[index]);
        }

        static string azericeSayilar(int index)
        {
            Dictionary<int, string> metinselIfadeler = new Dictionary<int, string>();

            metinselIfadeler.Add(0, "sıfır");
            metinselIfadeler.Add(1, "bir");
            metinselIfadeler.Add(2, "iki");
            metinselIfadeler.Add(3, "üç");
            metinselIfadeler.Add(4, "dörd");
            metinselIfadeler.Add(5, "beş");
            metinselIfadeler.Add(6, "altı");
            metinselIfadeler.Add(7, "yeddi");
            metinselIfadeler.Add(8, "Səkkiz");
            metinselIfadeler.Add(9, "Doqquz");
            metinselIfadeler.Add(10, "on");
            metinselIfadeler.Add(11, "on bir");
            metinselIfadeler.Add(12, "on iki");
            metinselIfadeler.Add(13, "on üç");
            metinselIfadeler.Add(14, "on dörd");
            metinselIfadeler.Add(15, "on beş");
            metinselIfadeler.Add(16, "on altı");
            metinselIfadeler.Add(17, "on yeddi");
            metinselIfadeler.Add(18, "on səkkiz");
            metinselIfadeler.Add(19, "on doqquz");
            metinselIfadeler.Add(20, "Iyirmi");
            metinselIfadeler.Add(30, "otuz");
            metinselIfadeler.Add(40, "Qırx");
            metinselIfadeler.Add(50, "Əlli");
            metinselIfadeler.Add(60, "altmış");
            metinselIfadeler.Add(70, "yetmiş");
            metinselIfadeler.Add(80, "Səksən");
            metinselIfadeler.Add(90, "Doxsan");
            metinselIfadeler.Add(100, "yüz");
            metinselIfadeler.Add(1000, "min");
            metinselIfadeler.Add(1000000, "milyon");
            metinselIfadeler.Add(1000000000, "milyard");

            return (metinselIfadeler[index]);
        }
    }
}
