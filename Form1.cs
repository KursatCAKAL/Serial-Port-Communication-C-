using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicDecimalToHex
{
    public partial class Form1 : Form
    {
        SerialPort myPort;
        byte[] data;
        public Form1()
        {
            InitializeComponent();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            

            var testScrollValue = hScrollBarMain.Value;
            var hexValue = testScrollValue.ToString("X");
            labelDecimalValue.Text = hScrollBarMain.Value.ToString();
            labelHexValue.Text = hexValue;

            byte testArrayValue = Convert.ToByte(hexValue,16);

            data = new byte[] { 0x00, 0x64, 0x6A };

            data[0] = testArrayValue;
            //Console.WriteLine(data[0].GetType());

            byte testvov = data[1];
            Console.WriteLine(testvov);
            
            int hexValueTestInt = 100;
            string hexValueTestString = hexValueTestInt.ToString("X");
            int aa =Convert.ToInt32(hexValueTestString);

            int test = Convert.ToInt32(data[1].ToString(), 16);

            string data1 = data[1].ToString();
            string data2 = data[2].ToString();

            int testt = int.Parse(data[0].ToString(), System.Globalization.NumberStyles.HexNumber);
            int testt1 = int.Parse(data[1].ToString(), System.Globalization.NumberStyles.HexNumber);
            int testt2 = int.Parse(data[2].ToString(), System.Globalization.NumberStyles.HexNumber);

            string dataComingDec = testScrollValue.ToString();
            string dataComingHex = hexValue.ToString();


            Console.WriteLine(dataComingDec+":" + dataComingHex +"///"+data1 + " " + ":" + testt1.ToString()+ "----"+ data2+":"+testt2.ToString());

            //byte[] t = x.Split().Select(s => Convert.ToByte(s, 16)).ToArray();

            Console.WriteLine(testScrollValue);
            Console.WriteLine(hexValue);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myPort = serialPort1;

            
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (myPort.IsOpen)
                    myPort.Write(data, 0, 3);

            }
            catch (Exception)
            {

            }
        }

        private void buttonBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                myPort.PortName = "COM2";
                myPort.BaudRate = 19200;
                myPort.DataBits = 8;
                myPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
                myPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");

                myPort.Open();

                MessageBox.Show("bağlantı tamam");
            }
            catch (Exception)
            {

                MessageBox.Show("bağlantı başarısız");

            }
        }
    }
}
