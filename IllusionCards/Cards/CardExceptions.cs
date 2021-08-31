namespace IllusionCards.Cards
{
	public class UnsupportedCardException : Exception
	{
		public string? CardPath;
		public UnsupportedCardException(string message, string? cardPath = null) : base(message) { CardPath = cardPath; }
		public UnsupportedCardException(string message, Exception ex, string? cardPath = null) : base(message, ex) { CardPath = cardPath; }
	}
	public class InvalidCardException : UnsupportedCardException
	{
		public InvalidCardException(string message) : base(message) { }
		public InvalidCardException(string message, Exception ex) : base(message, ex) { }
	}
	internal class InternalCardException : InvalidCardException
	{
		public InternalCardException(string message) : base(message) { }
		public InternalCardException(string message, Exception ex) : base(message, ex) { }
	}
}
