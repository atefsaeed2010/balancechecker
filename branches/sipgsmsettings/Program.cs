using System;
using System.IO;
using System.ServiceProcess;
using NETCONLib;
using NetFwTypeLib;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Script.Serialization; // Add reference: System.Web.Extensions
using System.Xml;
using System.Xml.Serialization;
using Helpers;

namespace BalanceChecker
{
	class Program
	{	
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		/// 


		static void Main()
		{
#if (DEBUG)

			string xml = File.ReadAllText(@"c:\Program Files (x86)\SipGsmGateway\Cfg\359124037819476");
			var conf = xml.ParseXML<config>();


			using (TextWriter writer = File.CreateText("d:\\perl.xml"))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(config));
				serializer.Serialize(writer, conf);
				//conf.Serialize("d:\\perl.xml");
			}			

			return;

			new Service();
			return;
#endif
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[] 
			{ 
				new Service()
			};
			ServiceBase.Run(ServicesToRun);

		}
	}
}
