using System;

namespace UsbUirt
{
	/// <summary>
	/// Evento args que � o que cont�m os dados do evento LearnCompleted
	/// </summary>
	public class LearnCompletedEventArgs : EventArgs
	{
        
		private Exception _error;///mensagem de erro
		private bool _cancelled;
		private string _code;
		private object _userState;

		internal LearnCompletedEventArgs(
			Exception error,
			bool cancelled,
			string code, 
			object userState
			)
		{
			_error = error;
			_cancelled = cancelled;
			_code = code;
			_userState = userState;
		}

		/// <summary>
		/// Lan�a qualquer exce��o no momento que estiver Learning.
		/// </summary>
		public Exception Error 
		{
			get 
			{
				return _error;
			}
		}

		/// <summary>
		/// Quando o Learning � cancelado.
		/// </summary>
		public bool Cancelled
		{
			get 
			{ 
				return _cancelled;
			}
		}

		/// <summary>
		/// Recebe o c�digo aprendido se completado com sucesso
		/// </summary>
		public string Code
		{
			get 
			{ 
				if (_cancelled) 
				{
					throw new InvalidOperationException("Learning was cancelled.");
				}
				return _code;
			}
		}

		/// <summary>
		/// Gets the optional user state.
		/// </summary>
		public object UserState
		{
			get 
			{
				return _userState; 
			}
		}
	}
}
