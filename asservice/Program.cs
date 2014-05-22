using System.ServiceProcess;

namespace BalanceChecker
{
	class Program
	{	
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		static void Main()
		{
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[] 
			{ 
				new Service()
			};
			ServiceBase.Run(ServicesToRun);
		}

	}
}
