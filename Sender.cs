﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace BalanceChecker
{
	class Sender
	{
		SerialPort port;
		public Sender(string portName)
		{
			port = new SerialPort();
			port.PortName = portName;
			port.WriteTimeout = Settings.Default.SerialPortTimeout;
			port.ReadTimeout = Settings.Default.SerialPortTimeout;

			try
			{
				port.Open();
				foreach (var item in Settings.Default.CheckBalanceNumberList)
				{
					SendUSSD(item);
					Thread.Sleep(5000);
				}
				port.Close();
			}
			catch (Exception)
			{
				port.Dispose();
				return;
			}
		}

		public void SendUSSD(string code)
		{
			var hexString = PduBitPacker.ConvertBytesToHex(PduBitPacker.PackBytes(Encoding.ASCII.GetBytes(code)));
			port.Write("AT+CUSD=1," + hexString + ",15\r");
		}
	}
}
