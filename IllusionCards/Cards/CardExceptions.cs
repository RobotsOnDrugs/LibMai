namespace IllusionCards.Cards
{
	public class UnsupportedCardException : Exception
	{
		public string CardPath;
		public UnsupportedCardException(string cardPath, string message) : base(message)
		{
			CardPath = cardPath;
		}
	}
	public class InvalidCardException : UnsupportedCardException
	{
		public InvalidCardException(string cardPath, string message) : base(cardPath, message) { }
	}
	internal class InternalCardException : InvalidOperationException
	{
		public InternalCardException(string message) : base(message) { }
	}
}
