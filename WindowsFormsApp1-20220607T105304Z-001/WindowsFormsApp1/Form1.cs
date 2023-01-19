using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        public Form1()
        {
            InitializeComponent();

            try
            {
                string hostname = "127.0.0.1";
                int port = 8000;
                s.Connect(hostname, port);
                MessageBox.Show("Polaczono");
            }
            catch
            {
                MessageBox.Show("Nie polaczono");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string ramka = textBox_diody.Text + textBox3.Text + textBox5.Text + "]";
            textBox1.Text = ramka;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ramka = textBox_diody.Text + textBox3.Text + textBox5.Text + "]";
            textBox1.Text = ramka;
            Byte[] ramka1 = Encoding.ASCII.GetBytes(textBox_diody.Text + textBox3.Text + textBox5.Text +"]");
            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rozkaz = "[01";
            textBox_diody.Text = rozkaz;
            Byte[] ramka1 = Encoding.ASCII.GetBytes(rozkaz + "0000]");
            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rozkaz = "[02";
            textBox_diody.Text = rozkaz;
            Byte[] ramka1 = Encoding.ASCII.GetBytes(rozkaz + "0000]");
            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string rozkaz = textBox_diody.Text;
            Byte[] ramka1 = Encoding.ASCII.GetBytes(rozkaz + "1010]");
            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string rozkaz = "[00";
            Byte[] ramka1 = Encoding.ASCII.GetBytes(rozkaz + "1000]");
            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string rozkaz = "[00";
            Byte[] ramka1 = Encoding.ASCII.GetBytes(rozkaz + "0010]");
            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string rozkaz = "[03";
            textBox_diody.Text = rozkaz;
            Byte[] ramka1 = Encoding.ASCII.GetBytes(rozkaz + "0000]");

            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox2.Text =  trackBar1.Value.ToString();
            int value = Convert.ToInt32(trackBar1.Value);
            if (value < 0)
            {
                value = value + 255;
            }
            string ramka2 = String.Format("{0:X}", value);
            
            textBox3.Text = ramka2.ToString();

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = trackBar2.Value.ToString();
            int value = Convert.ToInt32(trackBar2.Value);
            if (value < 0)
            {
                value = value + 255;
            }
            string ramka3 = String.Format("{0:X}", value);

            textBox5.Text = ramka3.ToString();
            
        }

        private void textBox_diody_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_odbierz_Click(object sender, EventArgs e)
        {
            byte[] przyjmij = new byte[256];
            NetworkStream odbierz = new NetworkStream(s);
            odbierz.Read(przyjmij, 0, 256);
            string returndata = System.Text.Encoding.ASCII.GetString(przyjmij);
            textBox_odbierz.Text = returndata;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string ramka = textBox6.Text;
            textBox6.Text = ramka;
            Byte[] ramka1 = Encoding.ASCII.GetBytes(ramka);
            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);
        }

       

        private void button9_Click(object sender, EventArgs e)
        {
            string rozkaz = "[00";
            textBox_diody.Text = rozkaz;
            Byte[] ramka1 = Encoding.ASCII.GetBytes(rozkaz + "0000]");

            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string rozkaz = "[00";
            textBox_diody.Text = rozkaz;
            Byte[] ramka1 = Encoding.ASCII.GetBytes(rozkaz + "]");

            NetworkStream wyslij = new NetworkStream(s);
            wyslij.Write(ramka1, 0, ramka1.Length);
        }
    }
}
