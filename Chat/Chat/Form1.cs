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
using System.Net;
namespace Chat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) // nick
        {
            /* Charact u = new Charact();
             textBox3.Text = u.user;*/
            //if (textBox3.Text == null) textBox1.Text = "Введите ник";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // field
        {
            const string adr = "127.0.0.1";
            const int port = 8888;
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(adr), port);
                Socket socket = new Socket(SocketType.Stream,ProtocolType.Tcp);
                socket.Connect(ip);
               // textBox3.Text = '>'.ToString();
                string message = textBox2.Text;
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);
                data = new byte[256];
                StringBuilder sb = new StringBuilder();
                int count = 0;
                do
                {
                    count = socket.Receive(data, data.Length, 0);
                    sb.Append(Encoding.Unicode.GetString(data, 0, count));
                } while (socket.Available > 0);
                textBox1.Text += sb.ToString();
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e) // text
        {
            
        }
    }
    class Obj
    {
            
    }
}