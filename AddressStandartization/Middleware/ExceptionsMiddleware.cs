using AddressStandartization.Exceptions;
using AddressStandartization.Responses;
using System.Text.Json;

namespace AddressStandartization.Middleware
{
	public class ExceptionsMiddleware
	{
		private readonly RequestDelegate next;

		public ExceptionsMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			ErrorResponse response = null;
			try
			{
				await next.Invoke(context);
			}
			catch (ProcessException pe)
			{
				response = pe.ToErrorResponse();
				context.Response.StatusCode = response.ErrorCode;
			}
			catch (HttpRequestException he)
			{
				response = he.ToErrorResponse();
				context.Response.StatusCode = response.ErrorCode;
			}
			catch (Exception e)
			{
				response = e.ToErrorResponse();
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
			}
			finally
			{
				if (response is not null)
				{
					context.Response.ContentType = "application/json";
					await context.Response.WriteAsync(JsonSerializer.Serialize(response));
					await context.Response.StartAsync();
					await context.Response.CompleteAsync();
				}
			}
		}
	}
}
