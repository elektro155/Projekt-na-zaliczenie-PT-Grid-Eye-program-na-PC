using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)  //otwieranie portu com
            { serialPort1.Open(); }
            
        }
        
         private void timer1_Tick(object sender, EventArgs e) //timer pełni tu rolę odświeżania "ekranu"
         {
     
            if (serialPort1.IsOpen && serialPort1.BytesToRead > 0)
            {
                String dane;
                dane = serialPort1.ReadExisting();
                if (dane == "ok")  //wykryto obiekt, moduł wysłał napis ok
                {
                    richTextBox1.Text = "OBJECT DETECTED";
                    richTextBox1.BackColor = System.Drawing.Color.Red;    //tło czerwone      
                    //System.Threading.Thread.Sleep(1000);
                }
                if (dane == "NO")  //nic nie wykryto, moduł wysyłał napis NO
                {
                    richTextBox1.Text = "NOTHING FOUND";
                    richTextBox1.BackColor = System.Drawing.Color.Lime; //tło zielone
                    
                }
            }
         }
       
        
    }
}
