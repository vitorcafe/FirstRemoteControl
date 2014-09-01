using System;

namespace UsbUirt
{
	/// <summary>
	/// Define especiais modifica��es quando h� o aprendizado dos c�digos IR.
	/// </summary>
	public enum LearnCodeModifier 
	{
		/// <summary>
		/// Usado  aprendizado padr�o.
		/// </summary>
		None = 0x0000,
		/// <summary>
		/// For�ar modo raw.
		/// </summary>
		ForceRaw = 0x0100,
		/// <summary>
		/// For�ar Struct-mode.
		/// </summary>
		ForceStruct = 0x0200,
		/// <summary>
		/// For�ar uma particular frequencia.
		/// </summary>
        /// <remarks> Quando (e somente quando) usando ForceFrequency, voc� 
        /// deve chamar a sobrecarga apropriada do Learn () ou LearnAsync () e fornecer o valor da frequ�ncia esperada.</remarks>
		ForceFrequency = 0x0400,
		/// <summary>
		/// Detecta autom�ticamente a frequ�ncia.
		/// </summary>
		FrequencyDetect = 0x0800
	}
}
