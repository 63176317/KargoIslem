using System.ComponentModel;

namespace Kargoİslemi
{
    class Program
    {

        static void Main(string[] args)
        {

            int index = -1;
            List<KargoSınıfı> kargolar = new List<KargoSınıfı>();

            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Yeni paket oluştur - 1\nPaket görüntüle - 2\nPaket karşılaştır - 3\nPaket bilgilerini değiştir - 4\nÇıkış için herhangi bir harfe başın");
                    var islem = int.Parse(Console.ReadLine());
                    switch (islem)
                    {
                        case 1://Yeni paket oluştur
                            try
                            {
                                Console.Clear();
                                index++;

                                kargolar.Add(new KargoSınıfı { });
                                bool aynıİsim = false;
                                string isim;
                                do
                                {
                                    aynıİsim = false;
                                    Console.Write("Paket için isim girin(4-14 karakter olmalı):");
                                    isim = Console.ReadLine().Trim().ToUpper();
                                    foreach (var item in kargolar)
                                    {
                                        if (item.editKargoPaketİsmi == isim)
                                        {
                                            aynıİsim = true;
                                        }
                                    }
                                    if (aynıİsim)
                                        Console.WriteLine("Bu isimde paket bulunmakta isim değiştirin");
                                } while (aynıİsim);
                                kargolar[index].editKargoPaketİsmi = isim;
                                KargoSınıfı.paketİsimHatası(kargolar[index].editKargoPaketİsmi);

                                Console.Write("Teslim edilecek adres Mahalle:");
                                kargolar[index][0] = Console.ReadLine().Trim();
                                Console.Write("Teslim edilecek adres İlçe:");
                                kargolar[index][1] = Console.ReadLine().Trim();
                                Console.Write("Teslim edilecek adres İl:");
                                kargolar[index][2] = Console.ReadLine().Trim();
                                KargoSınıfı.paketAdresHatası(kargolar[index][0]);
                                KargoSınıfı.paketAdresHatası(kargolar[index][1]);
                                KargoSınıfı.paketAdresHatası(kargolar[index][2]);
                                kargolar[index].setTeslimatMesafesi = kargolar[index].getTeslimatMesafesi();

                                Console.Write("Paket Ağırlığı gram cinsinden girin:");
                                kargolar[index].editKargoAgırlıgı = Convert.ToDouble(Console.ReadLine());
                                KargoSınıfı.agırlıkHatası(kargolar[index].editKargoAgırlıgı);

                                Console.Write("Paket boyutunu cm^3 cinsinden girin:");
                                kargolar[index].editKargoBoyutu = Convert.ToDouble(Console.ReadLine());
                                KargoSınıfı.boyutkHatası(kargolar[index].editKargoBoyutu);

                                Console.WriteLine("Teslimat hızlımı olsun 'evet' veya 'hayır'");
                                kargolar[index].setKargoHızlımı(Console.ReadLine());

                                Console.WriteLine("Teslimat eve mi yoksa ilçe şubesine mi 'evet' veya 'hayır'");
                                kargolar[index].setKargoEveTeslimi(Console.ReadLine());
                                Console.WriteLine("İşlem bitti");
                                Console.WriteLine("Ana menüye dönmek için 'enter' e basın");
                                Console.ReadLine();
                            }
                            catch (FormatException)
                            {
                                Console.Clear();
                                kargolar.RemoveAt(index);
                                Console.WriteLine("Yanlış girdi!!\nOluşturulan paket tamamen silindi!!!\nAna menüye dönülüyor");
                                index--;
                                Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                Console.ReadLine();
                                break;
                            }
                            catch (Exception ex)
                            {
                                kargolar.RemoveAt(index);
                                Console.Clear();
                                Console.WriteLine("Yanlış girdi!!\nOluşturulan paket tamamen silindi!!!\nAna menüye dönülüyor");
                                Console.WriteLine(ex.Message);
                                index--;
                                Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                Console.ReadLine();
                                break;
                            }

                            break;//Yeni paket oluştur bitti
                        case 2://Paket görüntüle
                            Console.Clear();

                            if (!(index == -1))
                            {
                                KargoSınıfı.yazdır1();
                                foreach (var item in kargolar)
                                {
                                    item.yazdır();
                                }
                                Console.WriteLine("Ana menüye dönmek için enter e basın");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Hiç görüntülenecek paket yok\nAna menüye dönülüyor");
                                Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                Console.ReadLine();
                            }
                            break;//Paket görüntüle bitti
                        case 3: //Paket karşılaştır
                            Console.Clear();

                            if (!(index <= 1))
                            {
                                try
                                {
                                    KargoSınıfı.yazdır1();
                                    foreach (var item in kargolar)
                                    {
                                        item.yazdır();
                                    }

                                    Console.Write("Karşılaştırmak istediğiniz 1. paket ismi:");
                                    string isim1 = Console.ReadLine();
                                    int paket1 = -1;
                                    int paket2 = -1;
                                    Console.Write("Karşılaştırmak istediğiniz 2. paket ismi:");
                                    string isim2 = Console.ReadLine();
                                    Console.Clear();
                                    KargoSınıfı.yazdır1();
                                    foreach (var item in kargolar)
                                    {
                                        if (item.editKargoPaketİsmi.ToLower() == isim1.ToLower())
                                        {
                                            paket1++;
                                            item.yazdır();
                                        }
                                    }
                                    if (paket1 == -1)
                                    {
                                        Console.WriteLine("Paket1 için girilen isim de paket yok");
                                        paket1 = int.Parse("dgfg");
                                    }
                                    foreach (var item in kargolar)
                                    {
                                        if (item.editKargoPaketİsmi.ToLower() == isim2.ToLower())
                                        {
                                            paket2++;
                                            item.yazdır();
                                        }
                                    }
                                    if (paket2 == -1)
                                    {
                                        Console.WriteLine("Paket2 için girilen isim de paket yok");
                                        paket1 = int.Parse("dgfg");
                                    }

                                    Console.WriteLine("Ana menüye dönmek için enter e basın");
                                    Console.ReadLine();
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ana menüye dönülüyor");
                                    Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                    Console.ReadLine();
                                }

                            }
                            else
                            {
                                Console.WriteLine("Karşılaştırma için en az üç paket olmalı paket yok\nAna menüye dönülüyor");
                                Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                Console.ReadLine();
                            }
                            break;//Paket karşılaştır bitti
                        case 4://Paket bilgilerini değiştir
                            Console.Clear();
                            if (!(index == -1))
                            {
                                KargoSınıfı.yazdır1();
                                foreach (var item in kargolar)
                                {
                                    item.yazdır();
                                }
                                Console.WriteLine("İşlem yapmak istediğiniz paket ismini girin:");
                                var isim = Console.ReadLine().Trim().ToUpper();
                                Console.Clear();
                                var varmı = -1;
                                int indexbul = -1;
                                KargoSınıfı.yazdır1();
                                foreach (var item in kargolar)
                                {
                                    indexbul++;
                                    if (item.editKargoPaketİsmi == isim)
                                    {
                                        varmı++;
                                        item.yazdır();
                                        break;
                                    }
                                }
                                string orjinal;
                                orjinal = kargolar[indexbul].editKargoPaketİsmi.PadRight(15);
                                orjinal += kargolar[indexbul][0].PadRight(14) + "/";
                                orjinal += kargolar[indexbul][1].PadRight(14) + "/";
                                orjinal += kargolar[indexbul][2].PadRight(15);
                                orjinal += Convert.ToString(kargolar[indexbul].editKargoAgırlıgı).PadRight(9);
                                orjinal += Convert.ToString(kargolar[indexbul].editKargoBoyutu).PadRight(10);
                                orjinal += Convert.ToString(kargolar[indexbul].getKargoHızlımı).PadRight(15);
                                orjinal += Convert.ToString(kargolar[indexbul].getKargoAdresemi).PadRight(15);
                                orjinal += Convert.ToString(kargolar[indexbul].getTeslimatucreti).Substring(0, 5).PadRight(9);
                                try
                                {
                                    if (varmı == -1)
                                    {
                                        Console.WriteLine("Böyle bir paket yok");
                                        varmı = int.Parse("dgf");
                                    }
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.WriteLine("Adres değişimi - 1\nGramaj değişimi - 2\nBoyut değişimi- 3\nAdrese teslim -4\nHızlı kargo- 5\n" +
                                            "Ana menüye dönmek için bir karaktere basın");
                                        int islem4 = int.Parse(Console.ReadLine());

                                        Console.Clear();
                                        switch (islem4)
                                        {
                                            case 1://Adres değişimi
                                                try
                                                {
                                                    Console.Write("Teslim edilecek adres Mahalle:");
                                                    kargolar[indexbul][0] = Console.ReadLine().Trim();
                                                    Console.Write("Teslim edilecek adres İlçe:");
                                                    kargolar[indexbul][1] = Console.ReadLine().Trim();
                                                    Console.Write("Teslim edilecek adres İl:");
                                                    kargolar[indexbul][2] = Console.ReadLine().Trim();
                                                    KargoSınıfı.paketAdresHatası(kargolar[indexbul][0]);
                                                    KargoSınıfı.paketAdresHatası(kargolar[indexbul][1]);
                                                    KargoSınıfı.paketAdresHatası(kargolar[indexbul][2]);
                                                    kargolar[index].setTeslimatMesafesi = kargolar[indexbul].getTeslimatMesafesi();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Yanlış girdi!!\nPaket bilgi değiştir menüsüne dönülüyor");
                                                    Console.WriteLine(ex.Message);
                                                    Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                                    Console.ReadLine();
                                                }
                                                break;//Adres değişimi bitti
                                            case 2://Gramaj değişimi
                                                try
                                                {
                                                    Console.Write("Paket Ağırlığı gram cinsinden girin:");
                                                    kargolar[indexbul].editKargoAgırlıgı = Convert.ToDouble(Console.ReadLine());
                                                    KargoSınıfı.agırlıkHatası(kargolar[indexbul].editKargoAgırlıgı);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Yanlış girdi!!\nPaket bilgi değiştir menüsüne dönülüyor");
                                                    Console.WriteLine(ex.Message);
                                                    Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                                    Console.ReadLine();
                                                }
                                                break;//Gramaj değişimi bitti
                                            case 3://Boyut değişimi
                                                try
                                                {
                                                    Console.Write("Paket boyutunu cm^3 cinsinden girin:");
                                                    kargolar[indexbul].editKargoBoyutu = Convert.ToDouble(Console.ReadLine());
                                                    KargoSınıfı.boyutkHatası(kargolar[indexbul].editKargoBoyutu);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Yanlış girdi!!\nPaket bilgi değiştir menüsüne dönülüyor");
                                                    Console.WriteLine(ex.Message);
                                                    Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                                    Console.ReadLine();
                                                }
                                                break;//Boyut değişimi bitti
                                            case 4://Adrese teslimimi değişimi
                                                try
                                                {
                                                    Console.WriteLine("Teslimat eve mi yoksa ilçe şubesine mi 'evet' veya 'hayır'");
                                                    kargolar[indexbul].setKargoEveTeslimi(Console.ReadLine());
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Yanlış girdi!!\nPaket bilgi değiştir menüsüne dönülüyor");
                                                    Console.WriteLine(ex.Message);
                                                    Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                                    Console.ReadLine();
                                                }
                                                break;//Adrese teslimimi değişimi bitt
                                            case 5://Hızlı kargo değişimi
                                                try
                                                {
                                                    Console.WriteLine("Teslimat hızlımı olsun 'evet' veya 'hayır'");
                                                    kargolar[indexbul].setKargoHızlımı(Console.ReadLine());
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Yanlış girdi!!\nPaket bilgi değiştir menüsüne dönülüyor");
                                                    Console.WriteLine(ex.Message);
                                                    Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                                    Console.ReadLine();
                                                }
                                                break;//Hızlı kargo değişimi bitti
                                            default:
                                                Console.WriteLine("Yanlış girdi!!\nPaket bilgi değiştir menüsüne dönülüyor");
                                                Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                                Console.ReadLine();
                                                break;
                                        }//switch sonu
                                        if (kargolar[indexbul].kayserimi())
                                        {//Kayseri içi
                                            if (kargolar[indexbul].getKargoHızlımı)
                                            {//kargo hızlı
                                                if (kargolar[indexbul].getKargoAdresemi)
                                                {//Kargo adrese
                                                    kargolar[indexbul].teslimatUcretiHesapla(kargolar[index].getKargoHızlımı, kargolar[index].editKargoAgırlıgı, kargolar[index].editKargoBoyutu, kargolar[index].getKargoAdresemi);
                                                }
                                                else
                                                {//Kargo adrese değil
                                                    kargolar[indexbul].teslimatUcretiHesapla(kargolar[index].getKargoHızlımı, kargolar[index].editKargoAgırlıgı, kargolar[index].editKargoBoyutu);
                                                }

                                            }
                                            else
                                            {//Kargo hızlı değil
                                                if (kargolar[indexbul].getKargoAdresemi)
                                                {//Kargo adrese
                                                    kargolar[indexbul].teslimatUcretiHesapla(kargolar[index].editKargoAgırlıgı, kargolar[index].editKargoBoyutu);

                                                }
                                                else
                                                {//Kargo adrese değil
                                                    kargolar[indexbul].teslimatUcretiHesapla(kargolar[index].editKargoAgırlıgı, kargolar[index].editKargoBoyutu);

                                                }
                                            }
                                        }
                                        else
                                        {//kayseri dışı
                                            if (kargolar[indexbul].getKargoHızlımı)
                                            {//kargo hızlı
                                                if (kargolar[indexbul].getKargoAdresemi)
                                                {//Kargo adrese
                                                    kargolar[indexbul].teslimatUcretiHesapla(kargolar[index].getKargoHızlımı, kargolar[index].editKargoAgırlıgı, kargolar[index].kayserimi(), kargolar[index].editKargoBoyutu, kargolar[index].getKargoAdresemi);

                                                }
                                                else
                                                {//Kargo adrese değil
                                                    kargolar[indexbul].teslimatUcretiHesapla(kargolar[index].getKargoHızlımı, kargolar[index].editKargoAgırlıgı, kargolar[index].kayserimi(), kargolar[index].editKargoBoyutu);

                                                }

                                            }
                                            else
                                            {//Kargo hızlı değil
                                                if (kargolar[indexbul].getKargoAdresemi)
                                                {//Kargo adrese
                                                    kargolar[indexbul].teslimatUcretiHesapla(kargolar[index].editKargoAgırlıgı, kargolar[index].kayserimi(), kargolar[index].editKargoBoyutu, kargolar[index].getKargoAdresemi);

                                                }
                                                else
                                                {//Kargo adrese değil
                                                    kargolar[indexbul].teslimatUcretiHesapla(kargolar[index].editKargoAgırlıgı, kargolar[index].kayserimi(), kargolar[index].editKargoBoyutu);

                                                }
                                            }
                                            Console.Clear();
                                            KargoSınıfı.yazdır1();
                                            Console.WriteLine("Eski hali");
                                            Console.WriteLine(orjinal);
                                            Console.WriteLine("Yeni hali");
                                            kargolar[indexbul].yazdır();
                                            Console.WriteLine("Paket bilgi değiştir menüsüne dönmek için 'enter' e basın");
                                            Console.ReadLine();

                                        }
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ana menüye dönülüyor");
                                    Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hiç görüntülenecek paket yok\nAna menüye dönülüyor");
                                Console.WriteLine("\nDevam etmek için 'enter' e basın");
                                Console.ReadLine();
                            }

                            break;//Paket bilgilerini değiştir bitti
                        default:
                            Console.WriteLine("Yanlış girdi!!\nAna menüye dönülüyor");
                            Console.WriteLine("\nDevam etmek için 'enter' e basın");
                            Console.ReadLine();
                            break;
                    }//switch sonu

                    //ücret hesaplama 
                    if (index >= 0)
                    {

                        if (kargolar[index].kayserimi())
                        {//Kayseri içi
                            if (kargolar[index].getKargoHızlımı)
                            {//kargo hızlı
                                if (kargolar[index].getKargoAdresemi)
                                {//Kargo adrese
                                    kargolar[index].teslimatUcretiHesapla(kargolar[index].getKargoHızlımı, kargolar[index].editKargoAgırlıgı, kargolar[index].editKargoBoyutu, kargolar[index].getKargoAdresemi);
                                }
                                else
                                {//Kargo adrese değil
                                    kargolar[index].teslimatUcretiHesapla(kargolar[index].getKargoHızlımı, kargolar[index].editKargoAgırlıgı, kargolar[index].editKargoBoyutu);
                                }

                            }
                            else
                            {//Kargo hızlı değil
                                if (kargolar[index].getKargoAdresemi)
                                {//Kargo adrese
                                    kargolar[index].teslimatUcretiHesapla(kargolar[index].editKargoAgırlıgı, kargolar[index].editKargoBoyutu);

                                }
                                else
                                {//Kargo adrese değil
                                    kargolar[index].teslimatUcretiHesapla(kargolar[index].editKargoAgırlıgı, kargolar[index].editKargoBoyutu);

                                }
                            }
                        }
                        else
                        {//kayseri dışı
                            if (kargolar[index].getKargoHızlımı)
                            {//kargo hızlı
                                if (kargolar[index].getKargoAdresemi)
                                {//Kargo adrese
                                    kargolar[index].teslimatUcretiHesapla(kargolar[index].getKargoHızlımı, kargolar[index].editKargoAgırlıgı, kargolar[index].kayserimi(), kargolar[index].editKargoBoyutu, kargolar[index].getKargoAdresemi);

                                }
                                else
                                {//Kargo adrese değil
                                    kargolar[index].teslimatUcretiHesapla(kargolar[index].getKargoHızlımı, kargolar[index].editKargoAgırlıgı, kargolar[index].kayserimi(), kargolar[index].editKargoBoyutu);

                                }

                            }
                            else
                            {//Kargo hızlı değil
                                if (kargolar[index].getKargoAdresemi)
                                {//Kargo adrese
                                    kargolar[index].teslimatUcretiHesapla(kargolar[index].editKargoAgırlıgı, kargolar[index].kayserimi(), kargolar[index].editKargoBoyutu, kargolar[index].getKargoAdresemi);

                                }
                                else
                                {//Kargo adrese değil
                                    kargolar[index].teslimatUcretiHesapla(kargolar[index].editKargoAgırlıgı, kargolar[index].kayserimi(), kargolar[index].editKargoBoyutu);

                                }
                            }
                        }

                    }

                }//while sonu
            }
            catch (FormatException)
            {
                Console.WriteLine("Çıkılıyor");
                Thread.Sleep(2500);
            }
        }//main sonu


    }//Class Program sonu
}