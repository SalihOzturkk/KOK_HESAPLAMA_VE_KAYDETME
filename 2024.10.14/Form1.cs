using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic; //inputbox ı kullanabilmek için bunu tanımlamamız lazım
//inputbox ı açmak için referanslardan visualbasic i eklemek gerekiyor

namespace _2024._10._14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar);



        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text != "")
            //{ 
            //if (Convert.ToInt32(textBox1.Text) < 1 ||
            //    Convert.ToInt32(textBox1.Text) > 9)
            //{
            //    MessageBox.Show("1 - 9 ARASINDA SAYI SEÇİNİZ"); 
            //}
            
            //}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (textBox2.Text != "")
            //{
            //    if (Convert.ToInt32(textBox2.Text) < 1 ||
            //        Convert.ToInt32(textBox2.Text) > 9)
            //    {
            //        MessageBox.Show("1 - 9 ARASINDA SAYI SEÇİNİZ");
            //    }

            //}
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //if (textBox3.Text != "")
            //{
            //    if (Convert.ToInt32(textBox3.Text) < 1 ||
            //        Convert.ToInt32(textBox3.Text) > 9)
            //    {
            //        MessageBox.Show("1 - 9 ARASINDA SAYI SEÇİNİZ");
            //    }

            //}
        }
        void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        double a, b, c, delta, tekkok, x1, x2;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                c = Convert.ToDouble(textBox3.Text);

                delta = (b * b) - (4 * a * c);

                if (delta < 0)
                {
                    MessageBox.Show("FONKSİYONUN REEL KÖKLERİ YOKTUR!!!");
                }
                if (delta == 0)
                {
                    tekkok = (-1 * b) / (2 * a);
                    StreamWriter kaydet1;
                    kaydet1 = File.AppendText("tekkok.txt");
                    kaydet1.WriteLine("A = " + a + " " + "B = " + b + " " +
                       "C = " + c + " " + "Tekkök = " + tekkok);
                    kaydet1.WriteLine("----------------------------------------------");
                    kaydet1.Close();
                    listBox1.Items.Add("A = " + a + " " + "B = " + b + " " +
                       "C = " + c + " " + "Tekkök = " + tekkok);
                    MessageBox.Show("Kök tekkok.txt Dosyasına kaydedildi!!");
                }
                if (delta > 0)
                {
                    x1 = ((-1 * b) + Math.Sqrt(delta)) / (2 * a);
                    x2 = ((-1 * b) - Math.Sqrt(delta)) / (2 * a);
                    StreamWriter kaydet2;
                    kaydet2 = File.AppendText("ciftkok.txt");
                    kaydet2.WriteLine("A = " + a + " " + "B = " + b + " " +
                       "C = " + c + " " + "X1 = "+Math.Round (x1)+" "+"X2 = "+Math.Round( x2));
                    kaydet2.WriteLine("----------------------------------------------");
                    kaydet2.Close();
                    listBox1.Items.Add("A = " + a + " " + "B = " + b + " " +
                       "C = " + c + " " + "X1 = " + Math.Round(x1) + " " + "X2 = " + Math.Round(x2));
                    MessageBox.Show("Kök ciftkok.txt Dosyasına kaydedildi!!");
                }
                
            }
            catch
            {
                MessageBox.Show("SAYISAL DEĞER GİRİNİZ!!!");
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string veriler;    StreamReader oku;
            oku = File.OpenText("ciftkok.txt");
            while((veriler=oku.ReadLine()) !=null)
            {
                listBox2.Items.Add(veriler);
            }
            oku.Close();
        }
        Int32 deger;

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //inputbox ı çağımak için interaction yazmak gerekiyor
                deger = Convert.ToInt32(Interaction.InputBox("Herhangi bir sayı giriniz",
                    "SAYI GİRİŞİ", "Buraya yazınız"));
                textBox4.Text = "Girilen Sayı  :" + deger;

            }
            catch
            {
                MessageBox.Show("LÜTFEN SAYI GİRİNİZ");
            }
        }
    }
}
