using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;
using rirais.Application.User.Exceptions;
using rirais.Domain.Common;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (DbUpdateException ex)
            when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
        {
            await HandleExceptionAsync(
                context, TranslateUniqueConstraintError(sqlEx.Message), HttpStatusCode.BadRequest
            );
        }
        catch (AbstractException ex)
        {
            await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, "Something went wrong", HttpStatusCode.InternalServerError);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode)
    {
        var response = new
        {
            error = message,
            statusCode = (int)statusCode
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private string TranslateUniqueConstraintError(string message)
    {
        if (message.Contains("Users_NationalCode", StringComparison.OrdinalIgnoreCase))
            return new DuplicateNationalCodeException().Message;

        return "A unique constraint was violated.";
    }
}