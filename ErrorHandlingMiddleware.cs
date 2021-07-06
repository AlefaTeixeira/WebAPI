using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ErrorHandlingMiddleware {

    private readonly RequestDelegate Next;
    public ErrorHandlingMiddleware(RequestDelegate next) {
        
        this.Next = next;
    }

    public async Task Invoke (HttpContext context) {
        try{
        await Next(context);
    }
    catch (Exception ex) {
        await HandleExceptionAync(context, ex);

    }
}
    private static Task HandleExceptionAync(HttpContext context, Exception ex) {
        var code = HttpStatusCode.InternalServerError;
        if(ex is ArgumentNullException){
            code = HttpStatusCode.BadRequest;
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(JsonSerializer.Serialize(new { erro = ex.Message }));
    }
}