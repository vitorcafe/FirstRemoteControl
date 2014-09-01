using System;

namespace UsbUirt
{
	/// <summary>
	/// Event args passed to the Received event
	/// </summary>
	public class ReceivedEventArgs : EventArgs
	{
		private string _irCode;

		internal ReceivedEventArgs(string irCode)
		{
			_irCode = irCode; ///guarda o código IR numa variável _irCode
		}

		/// <summary>
		/// Gets the received IR code.
		/// </summary>
		public string IRCode 
		{
			get 
			{
				return _irCode;  ///retorna o valor para a variável
			}
		}
	}
}
