using System;
using UsbUirt;
using System.Threading;

//using UsbUirt.Enums;
//using UsbUirt.EventArgs;
//using UsbUirt.AssemblyInfo;
//using CodeFormat;
//using Controller;
//using LearnCodeModifier;
//using LearnCompleteEventArgs;
//using LearnState;
//using ReceivedEventArgs;
//using SyncLearResult;
//using TransmitCompletedEventArgs;
//using TransmitState;

namespace TestApp
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class TestApp
	{
        /// <summary>
        /// ir= c�digo hexadecimal inicial
        /// </summary>
		private static string irCode = "0000 0071 0000 0032 0080 0040 0010 0010 0010 0030 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0030 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0030 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0030 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0030 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0010 0030 0010 0aad";
		/// <summary>
        /// CodeFormat = Define o formato dos c�digos quando usados para transmitir ou aprender c�digos IR
        private static CodeFormat transmitFormat = CodeFormat.Pronto;
		private static LearnCompletedEventArgs learnCompletedEventArgs = null; ///� anulado o Evento LearnCompleted
		
		/// <summary>
		/// Ponto de entrada da aplica��o
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try 
			{
				RunTestApp(); ///roda o app
			}
			catch(Exception ex) /// a exce��o lida caso n�o consiga rodar o app
			{
				Console.WriteLine("An exception was thrown: {0}", ex.ToString()); 
				Console.WriteLine("Press return to exit.");
				Console.ReadLine();
			}
		}

		private static void RunTestApp()   ///roda o app
		{
			Console.WriteLine("UUIRTDRV Example Program..."); 
			Console.WriteLine("===========================");

			if (Controller.DriverVersion != 0x0100) /// invalida se a vers�o for diferente
			{
				Console.WriteLine("ERROR: Invalid uuirtdrv version!\n");
				return;
			}

    			using (Controller mc = new Controller())  ///atribui o controle a vari�vel mc
			{
				mc.Received += new UsbUirt.Controller.ReceivedEventHandler(mc_Received); ///
				Console.WriteLine("USB-UIRT Info: Protocol: Version={0} Firmware: Version={1} Date={2}",
					mc.ProtocolVersion, mc.FirmwareVersion, mc.FirmwareDate.ToShortDateString());

				while(DoLoop(mc) == true);
				mc.Received -= new UsbUirt.Controller.ReceivedEventHandler(mc_Received);
			}
		}

		private static bool DoLoop(Controller mc) 
		{
			string toDo = String.Empty;
			do 
			{
				Console.WriteLine("\nUsbUirt Managed Wrapper Test Menu v0.5:");
				Console.WriteLine("---------------------------------------");
				Console.WriteLine("(1) Transmitir Codigo IR (bloqueado)");
				Console.WriteLine("(2) Transmitir Codigo IR (nao bloqueado)");
				Console.WriteLine("(3) Aprender Codigo IR (Pronto Format)");
                Console.WriteLine("(4) Aprender Codigo IR (UIRT-Raw Format)");
				Console.WriteLine("(5) Aprender Codigo IR (UIRT-Struct Format)");
				Console.WriteLine("(6) Ligar BlinkOnReceive {0}", mc.BlinkOnReceive ? "off" : "on");
				Console.WriteLine("(7) Ligar BlinkOnTransmit {0}", mc.BlinkOnTransmit ? "off" : "on");
				Console.WriteLine("(8) Ligar GenerateLegacyCodesOnReceive {0}", mc.GenerateLegacyCodesOnReceive ? "off" : "on");
				Console.WriteLine("(x) Exit");
				Console.WriteLine("---------------------------------------");

				Console.WriteLine("Press a key...");
				toDo = Console.ReadLine();
			} while(toDo == String.Empty);

			switch(toDo[0]) 
			{
				case '1':
					Console.WriteLine("Transmitting IR Code (blocking)...");
					try 
					{
						mc.Transmit(irCode, transmitFormat, 10, TimeSpan.Zero);
					} 
					catch(Exception ex) 
					{
						Console.WriteLine("*** ERROR calling Transmit! ***" + "\n"+ ex);
						throw;
					}
					Console.WriteLine("...Returned from call (Done)!");
				break;

				case '2':
					using (ManualResetEvent waitEvent = new ManualResetEvent(false))
					{
						mc.TransmitCompleted += new UsbUirt.Controller.TransmitCompletedEventHandler(mc_TransmitCompleted);
						Console.WriteLine("\nTransmitting IR Code (non-blocking)...");
						try 
						{
							mc.TransmitAsync(irCode, transmitFormat, 10, TimeSpan.Zero, waitEvent);
							Console.WriteLine("...Returned from call...");
							if (waitEvent.WaitOne(5000, false))
							{
								Console.WriteLine("...IR Transmission Complete!");
							}
							else
							{
								Console.WriteLine("*** ERROR: Timeout error waiting for IR to finish!");
							}
						} 
						catch(Exception ex) 
						{
							Console.WriteLine("*** ERROR calling TransmitAsync! ***");
							throw;
						}
						finally 
						{
							mc.TransmitCompleted -= new UsbUirt.Controller.TransmitCompletedEventHandler(mc_TransmitCompleted);
						}
					}
					break;

				case '3':
					TestLearn(mc, CodeFormat.Pronto, LearnCodeModifier.None);
					break;

				case '4':
					TestLearn(mc, CodeFormat.Uuirt, LearnCodeModifier.None);
					break;

				case '5':
					TestLearn(mc, CodeFormat.Uuirt, LearnCodeModifier.ForceStruct);
					break;

				case '6':
					mc.BlinkOnReceive = ! mc.BlinkOnReceive;
					break;

				case '7':
					mc.BlinkOnTransmit = ! mc.BlinkOnTransmit;
					break;

				case '8':
					mc.GenerateLegacyCodesOnReceive = ! mc.GenerateLegacyCodesOnReceive;
					break;

				case 'x':
					return false;

				default:
					break;
			}
			return true;
		}

		private static void mc_TransmitCompleted(object sender, TransmitCompletedEventArgs e)
		{
			ManualResetEvent waitEvent = e.UserState as ManualResetEvent;
			waitEvent.Set();
		}

		private static void TestLearn(Controller mc, CodeFormat learnFormat, LearnCodeModifier learnCodeModifier) 
		{
			learnCompletedEventArgs = null;
			Console.WriteLine("<Press x to abort Learn>");
			mc.Learning += new UsbUirt.Controller.LearningEventHandler(mc_Learning);
			mc.LearnCompleted += new UsbUirt.Controller.LearnCompletedEventHandler(mc_LearnCompleted);

			try 
			{
				try 
				{
					mc.LearnAsync(learnFormat, learnCodeModifier, learnCompletedEventArgs);

				} 			
				catch(Exception ex) 
				{
				Console.WriteLine("*** ERROR calling LearnAsync! ***");
					throw;
				}

				while (learnCompletedEventArgs == null) 
				{
					string s = Console.ReadLine();
					if (s.Length != 0 && s[0] == 'x') 
					{
						if (learnCompletedEventArgs == null) 
						{
							Console.WriteLine("Calling LearnAsyncCancel...");
							mc.LearnAsyncCancel(learnCompletedEventArgs);
							Thread.Sleep(1000);
							break;
						}
					} 
					else 
					{
						Console.WriteLine("<Press x to abort Learn>");
					}
				}

				if (learnCompletedEventArgs != null && 
					learnCompletedEventArgs.Cancelled == false &&
					learnCompletedEventArgs.Error == null) 
				{
					irCode = learnCompletedEventArgs.Code;
					Console.WriteLine("...Done...IRCode = {0}", irCode);
					transmitFormat = learnFormat;
				}

			} 
			finally 
			{
				mc.Learning -= new UsbUirt.Controller.LearningEventHandler(mc_Learning);
				mc.LearnCompleted -= new UsbUirt.Controller.LearnCompletedEventHandler(mc_LearnCompleted);
			}

		}

		private static void mc_Learning(object sender, LearningEventArgs e)
		{
			Console.WriteLine("Learning: {0}% freq={1} quality={2}", e.Progress, e.CarrierFrequency, e.SignalQuality);
		}

		private static void mc_LearnCompleted(object sender, LearnCompletedEventArgs e)
		{
			learnCompletedEventArgs = e;
			Console.WriteLine("Learn complete. Press return to continue.");
		}

		private static void mc_Received(object sender, ReceivedEventArgs e)
		{
            String teste = "";
            teste = e.IRCode;
            Console.WriteLine("recebido {0}", teste);
           
            //Console.WriteLine("Received: {0}", e.IRCode);
		}
	}
}

