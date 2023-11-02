namespace AddressStandartization.Exceptions
{
	public class ProcessServerException : Exception
	{

		public ProcessServerException(string message) : base(message)
		{
		}

		public static void ThrowIf(Func<bool> predicate, string message)
		{
			if (predicate.Invoke())
				throw new ProcessServerException(message);
		}
	}
}
