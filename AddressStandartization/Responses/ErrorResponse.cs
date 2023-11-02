using AddressStandartization.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace AddressStandartization.Responses
{
	public class ErrorResponse
	{
		public int ErrorCode { get; set; }
		public string Message { get; set; } = string.Empty;
	}

	public static class ErrorResponseExtensions
	{
		/// <summary>
		/// Convert process exception to ErrorResponse
		/// </summary>
		/// <param name="data">Process exception</param>
		/// <returns></returns>
		public static ErrorResponse ToErrorResponse(this ProcessException data)
		{
			var res = new ErrorResponse()
			{
				ErrorCode = data.Code,
				Message = data.Message
			};

			return res;
		}
		public static ErrorResponse ToErrorResponse(this HttpRequestException data)
		{
			var res = new ErrorResponse()
			{
				ErrorCode = (int)data.StatusCode!,
				Message = data.Message
			};

			return res;
		}
		/// <summary>
		/// Convert exception to ErrorResponse
		/// </summary>
		/// <param name="data">Exception</param>
		/// <returns></returns>
		public static ErrorResponse ToErrorResponse(this Exception data)
		{
			var res = new ErrorResponse()
			{
				ErrorCode = 500,
				Message = "Internal Server Error"
			};

			return res;
		}
	}
}
