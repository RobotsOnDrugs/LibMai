namespace IllusionCards.Cards
{
	public class UnsupportedCardException : Exception
	{
		public string CardPath;
		public UnsupportedCardException(string cardPath, string message) : base(message)
		{
			CardPath = cardPath;
		}
		public UnsupportedCardException(string cardPath, string message, Exception ex) : base(message, ex)
		{
			CardPath = cardPath;
		}
	}
	public class InvalidCardException : UnsupportedCardException
	{
		public InvalidCardException(string cardPath, string message) : base(cardPath, message) { }
		public InvalidCardException(string cardPath, string message, Exception ex) : base(cardPath, message, ex) { }
	}
	internal class InternalCardException : InvalidOperationException
	{
		public InternalCardException(string message) : base(message) { }
		public InternalCardException(string message, Exception ex) : base(message, ex) { }
	}
}
