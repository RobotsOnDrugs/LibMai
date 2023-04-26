namespace LibMai.Cards.Cards;

public class UnsupportedCardException : Exception
{
	public string? CardPath;
	public UnsupportedCardException(in string message, in string? cardPath = null) : base(message) => CardPath = cardPath;
	public UnsupportedCardException(in string message, in Exception ex, in string? cardPath = null) : base(message, ex) => CardPath = cardPath;
}
public class InvalidCardException : UnsupportedCardException
{
	public InvalidCardException(in string message) : base(message) { }
	public InvalidCardException(in string message, in Exception ex) : base(message, ex) { }
}
internal class InternalCardException : InvalidCardException
{
	public InternalCardException(in string message) : base(message) { }
	public InternalCardException(in string message, in Exception ex) : base(message, ex) { }
}
