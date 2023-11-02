namespace AddressStandartization.Exceptions
{
	public class ProcessException : Exception
	{
		public int Code { get; }

		public ProcessException()
		{
		}

		public ProcessException(string message) : base(message)
		{
		}

		public ProcessException(Exception inner) : base(inner.Message, inner)
		{
		}

		public ProcessException(string message, Exception inner) : base(message, inner)
		{
		}

		public ProcessException(int code, string message) : base(message)
		{
			Code = code;
		}

		public ProcessException(int code, string message, Exception inner) : base(message, inner)
		{
			Code = code;
		}


		public static void ThrowIf(Func<bool> predicate, int code, string message)
		{
			if (predicate.Invoke())
				throw new ProcessException(code, message);
		}
	}
}
