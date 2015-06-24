﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace mmf2client
{
    public partial class Form1 : Form
    {
 
        public Form1()
        {
            InitializeComponent();
        }

        tiesky.com.SharmIpc sm = null;
   

        Tuple<bool, byte[]> RemoteCall(byte[] data)
        {
            //Console.WriteLine("Received: {0} bytes", (data == null ? 0 : data.Length));
            return new Tuple<bool, byte[]>(true, new byte[] { 9, 4, 12, 17 });
        }



        private void button1_Click(object sender, EventArgs e)
        {

            if (sm == null)
                sm = new tiesky.com.SharmIpc("MyNewSharmIpc", this.RemoteCall);
         
        }


        /// <summary>
        /// Testing Requests without response
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000; i++)
            {
                // var res = sm.RpcCall(new byte[512], (par) => { });
                //var res = sm.RpcCall(null);
                //var res = sm.RpcCall(new byte[512]);
                sm.RemoteRequestWithoutResponse(new byte[512]);
                //sm.CallAndWaitAnswer("test", new byte[100000], 10 * 1000);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);


        }      

    }
}
