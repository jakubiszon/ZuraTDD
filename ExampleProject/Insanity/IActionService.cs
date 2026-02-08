using System.Collections.ObjectModel;

namespace ExampleProject.Insanity;

/// <summary>
/// An example interface with void methods taking up to 16 parameters.
/// The methods have assorted parameters using all (most?) built-in types.
/// </summary>
internal interface IActionService
{
	void A0();

	void A1(
		bool p1);

	void A2(
		byte p1,
		sbyte p2);

	void A3(
		double p1,
		decimal p2,
		float p3);

	void A4(
		int p1,
		uint p2,
		short p3,
		ushort p4);

	void A5(
		char p1,
		long p2,
		ulong p3,
		nint p4,
		nuint p5);

	void A6(
		object p1,
		string p2,
		int p3,
		Type p4,
		int p5,
		Exception p6);

	void A7(
		int[] p1,
		List<int> p2,
		Dictionary<string, int> p3,
		IEnumerable<string> p4,
		HashSet<int> p5,
		ReadOnlyCollection<string> p6,
		ReadOnlyDictionary<int, dynamic> p7);

	void A8(
		Exception p1,
		NullReferenceException p2,
		ArgumentException p3,
		ArgumentNullException p4,
		int p5,
		int p6,
		int p7,
		int p8);

	void A9(
		List<int> p1,
		List<char> p2,
		Memory<byte> p3,
		ReadOnlyMemory<string> p4,
		Func<int, string> p5,
		Action<string> p6,
		Predicate<int> p7,
		int p8,
		int p9);

	// assorted built-in types
	void A10(
		DateTime p1,
		DateOnly p2,
		DateTimeOffset p3,
		Uri p4,
		Guid p5,
		int p6,
		int p7,
		int p8,
		int p9,
		int p10);

	// async/await and related types
	void A11(
		Task p1,
		Task<int> p2,
		ValueTask p3,
		ValueTask<double> p4,
		TaskStatus p5,
		IAsyncEnumerable<string> p6,
		IAsyncEnumerator<int> p7,
		IAsyncDisposable p8,
		Thread p9,
		CancellationTokenSource p10,
		CancellationToken p11);

	void A12(
		StringComparison p1,
		int p2,
		int p3,
		int p4,
		int p5,
		int p6,
		int p7,
		int p8,
		int p9,
		int p10,
		int p11,
		int p12);

	// interfaces
	void A13(
		IDisposable p1,
		IComparable p2,
		IComparer<string> p3,
		IConvertible p4,
		ICloneable p5,
		int p6,
		int p7,
		int p8,
		int p9,
		int p10,
		int p11,
		int p12,
		int p13);

	void A14(
		int p1,
		int p2,
		int p3,
		int p4,
		int p5,
		int p6,
		int p7,
		int p8,
		int p9,
		int p10,
		int p11,
		int p12,
		int p13,
		int p14);

	// nullable
	void A15(
		string? p1,
		bool? p2,
		byte? p3,
		sbyte? p4,
		short? p5,
		ushort? p6,
		int? p7,
		uint? p8,
		long? p9,
		ulong? p10,
		Exception? p11,
		Guid? p12,
		Object? p13,
		Delegate? p14,
		Type? p15);

	// tuples yaaaay :D
	void A16(
		object p1,
		(int, int) p2,
		(int, int, int) p3,
		(int, int, int, int) p4,
		(int, int, int, int, int) p5,
		(int, int, int, int, int, int) p6,
		(int, int, int, int, int, int, int) p7,
		(int, int, int, int, int, int, int, int) p8,
		(int, int, int, int, int, int, int, int, int) p9,
		(int, int, int, int, int, int, int, int, int, int) p10,
		(int, int, int, int, int, int, int, int, int, int, int) p11,
		(int, int, int, int, int, int, int, int, int, int, int, int) p12,
		(int, int, int, int, int, int, int, int, int, int, int, int, int) p13,
		(int, int, int, int, int, int, int, int, int, int, int, int, int, int) p14,
		(int, int, int, int, int, int, int, int, int, int, int, int, int, int, int) p15,
		(int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int) p16);
}
