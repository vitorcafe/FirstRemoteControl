using System;

namespace UsbUirt
{
	/// <summary>
	/// Evento args que é o que contém os dados do evento LearnCompleted
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
		/// Lança qualquer exceção no momento que estiver Learning.
		/// </summary>
		public Exception Error 
		{
			get 
			{
				return _error;
			}
		}

		/// <summary>
		/// Quando o Learning é cancelado.
		/// </summary>
		public bool Cancelled
		{
			get 
			{ 
				return _cancelled;
			}
		}

		/// <summary>
		/// Recebe o código aprendido se completado com sucesso
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
