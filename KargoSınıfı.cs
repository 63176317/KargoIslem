using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargoİslemi
{
    class KargoSınıfı
    {
        //İsim değişkeni
        private string kargoPaketİsmi;
        public string editKargoPaketİsmi
        {
            get
            {
                return kargoPaketİsmi;
            }
            set
            {
                kargoPaketİsmi = value;
            }
        }
        public static void paketİsimHatası(string isim)
        {
            if (isim.Length < 14 && isim.Length > 4)
            {

                if (isim == "")
                {
                    throw new Exception("İsim bos bırakılamaz");
                }
            }
            else
            {
                throw new Exception("İsim 4 - 14 karakter olmalı");
            }
        }

        //Adres değişkeni
        //1. index mahalle ismi
        //2.index ilçe ismi
        //3.index il ismi
        private string[] teslimatAdresi = new string[3];
        public string this[int index]
        {
            get
            {
                return teslimatAdresi[index];
            }
            set { teslimatAdresi[index] = value; }
        }
        public static void paketAdresHatası(string isim)
        {
            if (isim == "")
            {
                throw new Exception("Mahalle ilçe ve il ismi bos bırakılamaz");
            }

        }

        //Ağırlık değişkeni
        //Gram cinsinden olacak
        private double kargoAgırlıgı;
        public static void agırlıkHatası(double kargoAgırlıgıa)
        {
            if (kargoAgırlıgıa <= 0)
            {
                throw new Exception("Ağırlık negatif olamaz!!!");
            }
        }
        public double editKargoAgırlıgı
        {
            get
            {
                return kargoAgırlıgı;
            }
            set
            {
                kargoAgırlıgı = value;
            }
        }

        //Boyut değişkeni
        //santimetre^3 cinsinden olacak
        private double kargoBoyutu;
        public static void boyutkHatası(double kargoAgırlıgıa)
        {
            if (kargoAgırlıgıa <= 0)
            {
                throw new Exception("Boyut negatif olamaz!!!");
            }
        }

        public double editKargoBoyutu
        {
            get
            {
                return kargoBoyutu;
            }
            set { kargoBoyutu = value; }
        }

        //Hızlı değişkeni
        //Teslimat hızlı olacak ise true
        private bool teslimatHızlımı;
        public void setKargoHızlımı(string kargoHızlımı)
        {
            if (kargoHızlımı.ToLower().Trim() == "evet")
            {
                this.teslimatHızlımı = true;
            }
            else if (kargoHızlımı.ToLower().Trim() == "hayır")
            {
                this.teslimatHızlımı = false;
            }
            else
            {
                throw new Exception("Kargo hızlımı?\n'Evet' veya 'hayır' dışında bir giriş oldu");
            }
        }
        public bool getKargoHızlımı
        {
            get { return teslimatHızlımı; }
        }

        //Adrese mi değişkeni
        //Teslimat adrese ise true
        private bool teslimatAdresemi;
        public void setKargoEveTeslimi(string kargoEveTeslimi)
        {
            if (kargoEveTeslimi.ToLower().Trim() == "evet")
            {
                this.teslimatAdresemi = true;
            }
            else if (kargoEveTeslimi.ToLower().Trim() == "hayır")
            {
                this.teslimatAdresemi = false;
            }
            else
            {
                throw new Exception("Kargo eve mi?\n'Evet' veya 'hayır' dışında bir giriş oldu");
            }
        }
        public bool getKargoAdresemi
        {
            get
            {
                return teslimatAdresemi;
            }
        }

        //Mesafe değişkeni
        //Km cinsinden olacak
        //Dosyadan okunacak
        private double teslimatMesafesi;
        public double setTeslimatMesafesi
        {
            get { return teslimatMesafesi; }
            set
            {
                teslimatMesafesi = value;
            }
        }
        public double getTeslimatMesafesi()
        {
            double sonuc1 = 0;
            if (File.Exists(@"C:\şehirUzaklığı\şehirUzaklıkları.txt"))
            {

                string sonuc = File.ReadAllText(@"C:\şehirUzaklığı\şehirUzaklıkları.txt");
                sonuc = sonuc.ToLower();
                string[] sehir_mesafe = sonuc.Split('!');
                int at = 0;
                foreach (var item in sehir_mesafe)
                {
                    if (item.StartsWith(teslimatAdresi[2].ToLower()))
                    {
                        at++;
                        string[] mesafe = item.Split(' ');
                        sonuc1 = Convert.ToDouble(mesafe[2]);
                        break;
                    }
                }
                if (!(at == 1))
                {
                    throw new Exception("Şehir ismi yanlış veya eksik");
                    at = 0;
                }
            }
            else
            {
                throw new Exception("Şehir uzaklıkları dosyası açılmadı\nDosya silinmiş veya adres bilgisi değiştirilmiş olabilir " +
                    "\n!!!!!!Lütfen Şehir uzaklıkları Projesini Çalıştırın!!!!!!!");
            }
            return sonuc1;
        }

        //Ücret değişkeni
        private double teslimatUcret;
        public double getTeslimatucreti
        {
            get { return teslimatUcret; }
        }

        public bool kayserimi()
        {
            var sonuc = false;
            if ("Kayseri".ToLower() == teslimatAdresi[2].ToLower())
            {
                sonuc = true;
            }
            return sonuc;
        }
        /*
         *Ücretlendirme aralığı
         *Ağırlık (0kg-1kg 3₺)  (1kg-10kg 7₺ )(10kg0-40kg 15₺ )(40kg> 26₺)
         *Boyut (0cm^3-500cm^3 4₺) (500cm^3-4500cm^3 9₺)(4500cm^3-15000cm^3 18)(15000cm^3> 30₺)
         *Mesafe(0km-150km  *0.2)(150km -450km *0.5)(450km> *0.7)
         *Hızlı kargo(fiyat +fiyat*%20)
         *Eve teslim(fiyat+20)
         *ücret=Ağırlık*boyut+varsa mesafe ücreti+varsa eve teslim+varsa hızlı kargo;
         */
        private int agırlıkUcreti()
        {
            int donus = 0;
            if (this.kargoAgırlıgı <= 1000 && this.kargoAgırlıgı > 0)
            {
                donus = 3;
            }
            else if (this.kargoAgırlıgı <= 10000 && this.kargoAgırlıgı > 1000)
            {
                donus = 7;
            }
            else if (this.kargoAgırlıgı <= 40000 && this.kargoAgırlıgı > 10000)
            {
                donus = 15;
            }
            else
            {
                donus = 26;
            }
            return donus;
        }

        private int boyutUcreti()
        {
            int donus = 0;
            if (this.kargoBoyutu <= 500 && this.kargoBoyutu > 0)
            {
                donus = 4;
            }
            else if (this.kargoBoyutu <= 4500 && this.kargoBoyutu > 500)
            {
                donus = 9;
            }
            else if (this.kargoBoyutu <= 45000 && this.kargoBoyutu > 15000)
            {
                donus = 18;
            }
            else
            {
                donus = 30;
            }
            return donus;
        }
        private double mesafeUcreti()
        {
            double donus = 0;
            if (this.teslimatMesafesi <= 150 && this.teslimatMesafesi > 0)
            {
                donus = this.teslimatMesafesi * 0.2;
            }
            else if (this.teslimatMesafesi <= 450 && this.teslimatMesafesi > 150)
            {
                donus = this.teslimatMesafesi * 0.5;
            }
            else
            {
                donus = this.teslimatMesafesi * 0.7;
            }
            return donus;
        }
        private double hızlıteslimatUcreti()
        {
            return this.teslimatUcret * 0.2;
        }
        //Kayseri deki sipariş 1
        public void teslimatUcretiHesapla(double agırlık, double bouyut)
        {
            this.teslimatUcret = agırlıkUcreti() * boyutUcreti();
        }
        //Kayseri deki sipariş 2
        public void teslimatUcretiHesapla(double agırlık, double bouyut, bool adreseTeslim)
        {
            this.teslimatUcret = agırlıkUcreti() * boyutUcreti() + 20;
        }
        //Kayseri deki sipariş 3
        public void teslimatUcretiHesapla(bool hızlıteslimat, double agırlık, double bouyut)
        {
            this.teslimatUcret = agırlıkUcreti() * boyutUcreti();
            this.teslimatUcret += hızlıteslimatUcreti();
        }

        //Kayseri deki sipariş 4
        public void teslimatUcretiHesapla(bool hızlıteslimat, double agırlık, double bouyut, bool adreseTeslim)
        {
            this.teslimatUcret = agırlıkUcreti() * boyutUcreti() + 20;
            this.teslimatUcret += hızlıteslimatUcreti();
        }

        //Kayseri dışındaki sipariş 1
        public void teslimatUcretiHesapla(double agırlık, bool kayserimi, double bouyut)
        {
            this.teslimatUcret = agırlıkUcreti() * boyutUcreti() + mesafeUcreti();
        }

        //Kayseri dışındaki sipariş 2
        public void teslimatUcretiHesapla(double agırlık, bool kayserimi, double bouyut, bool adreseTeslim)
        {
            this.teslimatUcret = agırlıkUcreti() * boyutUcreti() + mesafeUcreti() + 20;
        }

        //Kayseri dışındaki sipariş 3
        public void teslimatUcretiHesapla(bool hızlıteslimat, double agırlık, bool kayserimi, double bouyut, bool adreseTeslim)
        {
            this.teslimatUcret = agırlıkUcreti() * boyutUcreti() + mesafeUcreti() + 20;
            this.teslimatUcret += hızlıteslimatUcreti();
        }

        //Kayseri dışındaki sipariş 4
        public void teslimatUcretiHesapla(bool hızlıteslimat, double agırlık, bool kayserimi, double bouyut)
        {
            this.teslimatUcret = agırlıkUcreti() * boyutUcreti() + mesafeUcreti();
            this.teslimatUcret += hızlıteslimatUcreti();
        }
        public void yazdır()
        {
            Console.Write(kargoPaketİsmi.PadRight(15) + teslimatAdresi[0].PadRight(14) + "/" + teslimatAdresi[1].PadRight(14) + "/" +
                teslimatAdresi[2].PadRight(15) + Convert.ToString(kargoAgırlıgı).PadRight(9) + Convert.ToString(kargoBoyutu).PadRight(10) +
                Convert.ToString(teslimatHızlımı).PadRight(15) + Convert.ToString(teslimatAdresemi).PadRight(15));
            if(Convert.ToString(teslimatUcret).Length>=10)
            {
                Console.WriteLine(Convert.ToString(teslimatUcret).Substring(0,9).PadRight(10));
            }
            else
            {
                Console.WriteLine(Convert.ToString(teslimatUcret).PadRight(10));
            }
        }
        public static void yazdır1()
        {
            Console.WriteLine("Paket adı".PadRight(15) + "Adres Mahalle/İlçe/İl".PadRight(45) + "Ağırlık g".PadRight(9) + "Boyut cm^3".PadRight(10) + "Hızlı teslimat".PadRight(15)
                                   + "Adrese mi".PadRight(15) + "Ücret(TL)".PadRight(10));

            Console.WriteLine("**************".PadRight(15) + "*******************************************".PadRight(45) + "********".PadRight(10) + "********".PadRight(9) + "**************".PadRight(15)
                + "**************".PadRight(15) + "*********".PadRight(10));
        }
        
    }
}
