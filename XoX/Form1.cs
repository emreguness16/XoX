using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string sira = "X";   //butonlara bastığımda X ve O yu vermesi için gereken değişken-global değişken
        int sayac = 0;  // X ve O nun sırasını belirlemek için kullandığım sayac değişkeni-global değişken
        int beraberlikSayaci = 0;  // beraberliği kontrol etmek için gerekli sayac-global değişken
        int kazananSayaci = 0; // oyunu kazanan olduğu taktirde beraberliğin kontrolü için kazanan sayacının 0 olması lazım.kazanan olursa sayac artar-global değişken
        private void Form1_Load(object sender, EventArgs e)
        {
           // label2.Text = "X"; //oyun ilk başladığında label2 nin boş olmaması için
            // Solution Explorer daki Properties-Settings den formunun kaldığı yerden devam etmesi için bir string oluşturdum ve kaydettiğim form değişkenini içine attım
            label2.Text = Properties.Settings.Default.kaydet;  //formu kapatıp tekrar açtığımızda kaydettiği yerden devam etmesi için kullandım
            if (label2.Text == "O") //burada ve hemen altındaki if deyiminde değişkenimin (X veya O) kaldığı yerden devam etmesini sağlamak için değişkenleri düzenledim
            {
                sayac += 1;  //aynı değişkeni tekrar yazdırmaması için sıra (X veya O nun sırası) sayacını 1 artırdım
                sira = label2.Text.ToString();    //sıra değikenimi label2 deki harfe (X veya O) atadım (yanlış sonuç vermesin diye)
            }
            if(label2.Text=="X") //sıra değişkenini label2 den aldığım için , label2 nin text X ise ;
            {
                sira = label2.Text.ToString(); //sira değişkenimi label2 den al
            } 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;  //butona tıkladığımda beraberlik sayacını 1 artırdım
            button1.Enabled = false; //butonun tıklanma özelliğinin aktifliğini kaldırdım
            if (sayac % 2 == 0) // oyun ilk başladığında X den başlayacağı için 2. tıklamada yani çift sayıda tıklandığında sıra O ya geçecek
            {
                label2.Text = "O".ToString();  //sayac çift sayı ise (butonlara toplam birt çift sayı kadar tıklanırsa) sıra O'dadır
                sayac += 1;  //burada 1 artırmamızın sebebi sayacı çift sayıdan çıkarıp tek sayı yaparak sıranın X e geçmesini sağlıyorum
            }
            else
            {
                label2.Text = "X".ToString(); //sayac çift sayı değilse sıra X tedir
                sayac += 1; //sırayı X den sonra O ya geçirmek için sayacı tekrar 1 artırıyorum
            }
            if (button1.Text == "") //butonun üstünde X veya O yazmıyorsa :
            {
                button1.Text = sira.ToString();  //butonun text'ini siraya eşitleyip (X ise X , Y ise Y) butonun üstüne yazdırıyorum
                sira = label2.Text.ToString(); //sıra değikenimi label2 den aldığım için sırayı label2 ye eşitliyorum,bu şekilde sıradaki oyuncu değişebilecek
            }
            Properties.Settings.Default.kaydet = label2.Text;  //Properties-Settings den oluşturduğum stringin default (geçerli) olanını label2 nin text inden alıyorum
            Properties.Settings.Default.Save(); //label2 deki yazıyı (aynı anda sıra değişkenimizi) 

            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (button1.Text == button3.Text))
            {
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;  //kazanan sayacını beraberlik durumu için kontrol amaçlı artırıyorum//herhangi bir oyuncu kazanırsa kazanansayaci 1 artar
                
            }
            if ((button1.Text == button4.Text) && (button1.Text == button7.Text) && (button4.Text == button7.Text)) // bu if bloklarında 3 lü kombinasyonlar yaparak
            {                                                                                                       // oyunun kazananını belirliyoruz (çapraz , yan ve dikey üçlü kombinasyonlar)
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button1.Text == button5.Text) && (button1.Text == button9.Text) && (button5.Text == button9.Text))
            {
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if(beraberlikSayaci%9==0 && kazananSayaci < 1)  // oyunculardan biri kazanamazsa ve beraberlik sayacı 9 olursa  (9 kez tıklanmış ve kazanan olmamışsa) ve herhangi biri kazanmamışsa
                                                             // kazanan sayacı tutmamın sebebi oyuncuların herhangi birinin son butonda oyunu kazanması durumu için
            {
                button1.Enabled = true;  //butonların tıklanma özelliğini aktif ediyorum
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString(); //oyuncular berabere kalırsa otomatik olarak YENİ OYUN başlaması gerekiyor denildiği için sira O ya geçiyor
                sira = label2.Text;  //sıra değişkenimi yine label2 den alıyorum
                button1.Text = "";
                button2.Text = "";  //butonlarımın text ini boşaltıyorum
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }
            //DİĞER BÜTÜN BUTONLAR DA BUTTON1 İLE AYNI KODA SAHİP OLDUĞU İÇİN AÇIKLAMA SATIRLARINI YAZMADIM HOCAM (KODLAR 1'E 1 AYNI SADECE OYUNCULARIN KAZANMASI İÇİN GEREKLİ 3'ERLİ KOMBİNASYONLAR FARKLI)
        }
        private void button2_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;
            button2.Enabled = false;
            if (sayac % 2 == 0)
            {
                label2.Text = "O".ToString();
                sayac += 1;
            }
            else
            {
                label2.Text = "X".ToString();
                sayac += 1;

            }
            if (button2.Text == "")
            {
                button2.Text = sira.ToString();
                sira = label2.Text.ToString();
                

            }
            Properties.Settings.Default.kaydet = label2.Text;
            Properties.Settings.Default.Save();
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (button1.Text == button3.Text))
            {
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button2.Text == button5.Text) && (button2.Text == button8.Text) && (button5.Text == button8.Text))
            {
                MessageBox.Show(button2.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if (beraberlikSayaci % 9 == 0 && kazananSayaci != 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString();
                sira = label2.Text;
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;
            button3.Enabled = false;
            
            if (sayac % 2 == 0)
            {
                label2.Text = "O".ToString();
                sayac += 1;
            }
            else
            {
                label2.Text = "X".ToString();
                sayac += 1;
            }
            if (button3.Text == "")
            {
                button3.Text = sira.ToString();
                sira = label2.Text.ToString();
            }
            Properties.Settings.Default.kaydet = label2.Text;
            Properties.Settings.Default.Save();
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (button1.Text == button3.Text))
            {
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (button3.Text == button9.Text))
            {
                MessageBox.Show(button3.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (button3.Text == button7.Text))
            {
                MessageBox.Show(button3.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if (beraberlikSayaci == 9 && kazananSayaci != 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString();
                sira = label2.Text;
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;
            button4.Enabled = false;
            if (sayac % 2 == 0)
            {
                label2.Text = "O".ToString();  // bu if else bloğunda sıranın lable de "O" dan sonra "X" e veya tam tersi olarak dönüşmesini sağladım
                sayac += 1;
            }
            else
            {
                label2.Text = "X".ToString();
                sayac += 1;
            }
            if (button4.Text == "")
            {
                button4.Text = sira.ToString();
                sira = label2.Text.ToString();
            }
            Properties.Settings.Default.kaydet = label2.Text;
            Properties.Settings.Default.Save();
            if ((button1.Text == button4.Text) && (button1.Text == button7.Text) && (button4.Text == button7.Text))
            {
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button5.Text == button4.Text) && (button5.Text == button6.Text) && (button4.Text == button6.Text))
            {
                MessageBox.Show(button4.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if (beraberlikSayaci % 9 == 0 && kazananSayaci != 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString();
                sira = label2.Text; 
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;
            button5.Enabled = false;
            if (sayac % 2 == 0)
            {
                label2.Text = "O".ToString();  // bu if else bloğunda sıranın lable de "O" dan sonra "X" e veya tam tersi olarak dönüşmesini sağladım
                sayac += 1;
            }
            else
            {
                label2.Text = "X".ToString();
                sayac += 1;
            }
            if (button5.Text == "")
            {
                button5.Text = sira.ToString();
                sira = label2.Text.ToString();
            }
            Properties.Settings.Default.kaydet = label2.Text;
            Properties.Settings.Default.Save();
            if ((button1.Text == button5.Text) && (button1.Text == button9.Text) && (button5.Text == button9.Text))
            {
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button2.Text == button5.Text) && (button2.Text == button8.Text) && (button5.Text == button8.Text))
            {
                MessageBox.Show(button2.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (button3.Text == button7.Text))
            {
                MessageBox.Show(button3.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button5.Text == button4.Text) && (button5.Text == button6.Text) && (button4.Text == button6.Text))
            {
                MessageBox.Show(button4.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if (beraberlikSayaci % 9 == 0 && kazananSayaci != 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString();
                sira = label2.Text;
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;
            button6.Enabled = false;
            if (sayac % 2 == 0)
            {
                label2.Text = "O".ToString();  // bu if else bloğunda sıranın lable de "O" dan sonra "X" e veya tam tersi olarak dönüşmesini sağladım
                sayac += 1;
            }
            else
            {
                label2.Text = "X".ToString();
                sayac += 1;
            }
            if (button6.Text == "")
            {
                button6.Text = sira.ToString();
                sira = label2.Text.ToString();
            }
            Properties.Settings.Default.kaydet = label2.Text;
            Properties.Settings.Default.Save();
            if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (button3.Text == button9.Text))
            {
                MessageBox.Show(button3.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button5.Text == button4.Text) && (button5.Text == button6.Text) && (button4.Text == button6.Text))
            {
                MessageBox.Show(button6.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if (beraberlikSayaci % 9 == 0 && kazananSayaci != 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString();
                sira = label2.Text;
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;
            button7.Enabled = false;
            if (sayac % 2 == 0)
            {
                label2.Text = "O".ToString();  // bu if else bloğunda sıranın lable de "O" dan sonra "X" e veya tam tersi olarak dönüşmesini sağladım
                sayac += 1;
            }
            else
            {
                label2.Text = "X".ToString();
                sayac += 1;
            }
            if (button7.Text == "")
            {
                button7.Text = sira.ToString();
                sira = label2.Text.ToString();
            }
            Properties.Settings.Default.kaydet = label2.Text;
            Properties.Settings.Default.Save();
            if ((button1.Text == button4.Text) && (button1.Text == button7.Text) && (button4.Text == button7.Text))
            {
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (button3.Text == button7.Text))
            {
                MessageBox.Show(button3.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button7.Text == button8.Text) && (button7.Text == button9.Text) && (button8.Text == button9.Text))
            {
                MessageBox.Show(button7.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if (beraberlikSayaci % 9 == 0 && kazananSayaci != 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString();
                sira = label2.Text;
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;
            button8.Enabled = false;
            if (sayac % 2 == 0)
            {
                label2.Text = "O".ToString();  // bu if else bloğunda sıranın lable de "O" dan sonra "X" e veya tam tersi olarak dönüşmesini sağladım
                sayac += 1;
            }
            else
            {
                label2.Text = "X".ToString();
                sayac += 1;
            }
            if (button8.Text == "")
            {
                button8.Text = sira.ToString();
                sira = label2.Text.ToString();
            }
            Properties.Settings.Default.kaydet = label2.Text;
            Properties.Settings.Default.Save();
            if ((button2.Text == button5.Text) && (button2.Text == button8.Text) && (button5.Text == button8.Text))
            {
                MessageBox.Show(button2.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button7.Text == button8.Text) && (button7.Text == button9.Text) && (button8.Text == button9.Text))
            {
                MessageBox.Show(button7.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if (beraberlikSayaci % 9 == 0 && kazananSayaci != 1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString();
                sira = label2.Text;
                label2.Text = "O".ToString();
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            beraberlikSayaci += 1;
            button9.Enabled = false;
            if (sayac % 2 == 0)
            {
                label2.Text = "O".ToString();  // bu if else bloğunda sıranın lable de "O" dan sonra "X" e veya tam tersi olarak dönüşmesini sağladım
                sayac += 1;
            }
            else
            {
                label2.Text = "X".ToString();
                sayac += 1;
            }
            if (button9.Text == "")
            {
                button9.Text = sira.ToString();
                sira = label2.Text.ToString();
            }
            Properties.Settings.Default.kaydet = label2.Text;
            Properties.Settings.Default.Save();
            if ((button1.Text == button5.Text) && (button1.Text == button9.Text) && (button5.Text == button9.Text))
            {
                MessageBox.Show(button1.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (button3.Text == button9.Text))
            {
                MessageBox.Show(button3.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if ((button7.Text == button8.Text) && (button7.Text == button9.Text) && (button8.Text == button9.Text))
            {
                MessageBox.Show(button7.Text.ToString() + " kazandı!");
                kazananSayaci += 1;
            }
            if (beraberlikSayaci % 9 == 0 && kazananSayaci!=1)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                label2.Text = "O".ToString();
                sira = label2.Text;
                
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";
            }

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();  //menustrip in Dosya kısmındaki çıkışa basınca formu kapatmasını sağlıyorum
        }
        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kazananSayaci = 0;  //yeni oyun başladığında beraberliğin kontrolü için kazanan sayacını tekrar sıfırlıyorum
            beraberlikSayaci = 0; //yeni oyuna başlandığında oyuncuların berabere kalma ihtimaline karşı beraberlikSayaci ni sıfırlıyorum
            button1.Enabled = true;  
            button2.Enabled = true;
            button3.Enabled = true;  //yeni oyuna başlandığı için butonların tıklanma özelliklerini aktif ediyorum
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            label2.Text = "O".ToString();
            sira = "X"; //YENİ OYUN dendiği için bizden istenildiği üzere sıra O ya geçiyor
            sayac += 1;  //sıranın  doğru kalması için sayacı 1 artırıyorum , artırmazsam X den başlar yine 
            
            if(sayac%2==0)  //sayac çift sayı ise 
            {
                sira =label2.Text;   //sıra değikenini label 2 den al
            }
            else  //sıra çift ise 
            {
                sira = label2.Text;  //sıra değişkenini label2 den al
               
            }
            sayac += 2;
            if (sayac % 2 == 0)  //bu if else bloğu da sıra değişkeninin sırayla X ve O ya geçmesi için
            {
                sira = "X";  //sıra değikenini label 2 den al
                label2.Text = "X";
            }
            else  //sıra çift ise 
            {
                sira = "O";  //sıra değişkenini label2 den al
                label2.Text = "O";
               
            }
            
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";  //yeni oyun başladığı için butonların text lerini temizliyorum
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Geliştirici:Bilgisayar Mühendisi!");  //menustrip den eklediğimiz Yardım kısmına tıkladığımızda ekrana mesaj veriyoruz
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
