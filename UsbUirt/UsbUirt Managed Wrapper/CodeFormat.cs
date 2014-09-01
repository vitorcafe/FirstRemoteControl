using System;

namespace UsbUirt
{
	/// <summary>
	/// Define o formato dos códigos quando usados para transmitir ou aprender códigos IR
	/// </summary>
	public enum CodeFormat
	{
		/// <summary>
		/// Uuirt code format
		/// </summary>
		Uuirt = 0x0000,
		/// <summary>
		/// Pronto format
		/// </summary>
		Pronto = 0x0010
	}
}
