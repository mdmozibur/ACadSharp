﻿namespace ACadSharp.Entities
{
	/// <summary>
	/// Hatch pattern fill type.
	/// </summary>
	public enum HatchPatternType
	{
		/// <summary>
		/// Pattern fill.
		/// </summary>
		UserDefined = 0,
		/// <summary>
		/// Solid fill.
		/// </summary>
		PreDefined = 1,
		/// <summary>
		/// Custom hatch pattern from a pattern file.
		/// </summary>
		Custom = 2,
	}
}
