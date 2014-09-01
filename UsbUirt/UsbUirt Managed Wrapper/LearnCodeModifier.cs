using System;

namespace UsbUirt
{
	/// <summary>
	/// Define especiais modificações quando há o aprendizado dos códigos IR.
	/// </summary>
	public enum LearnCodeModifier 
	{
		/// <summary>
		/// Usado  aprendizado padrão.
		/// </summary>
		None = 0x0000,
		/// <summary>
		/// Forçar modo raw.
		/// </summary>
		ForceRaw = 0x0100,
		/// <summary>
		/// Forçar Struct-mode.
		/// </summary>
		ForceStruct = 0x0200,
		/// <summary>
		/// Forçar uma particular frequencia.
		/// </summary>
        /// <remarks> Quando (e somente quando) usando ForceFrequency, você 
        /// deve chamar a sobrecarga apropriada do Learn () ou LearnAsync () e fornecer o valor da frequência esperada.</remarks>
		ForceFrequency = 0x0400,
		/// <summary>
		/// Detecta automáticamente a frequência.
		/// </summary>
		FrequencyDetect = 0x0800
	}
}
