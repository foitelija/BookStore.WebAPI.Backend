using BookStore.Application.CustomsExceptions;
using BookStore.Application.DTOs.Errors;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace BookStore.Application.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound, "По вашему запросу ничего не найдено");
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest, "Ошибка запроса, проверьте правильность заполнения полей");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string exMessage, HttpStatusCode httpStatusCode, string message)
        {
            //тут можно добавить логгер. _logger.Error(exMessage);

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            string result = JsonSerializer.Serialize(errorDto);

            await response.WriteAsync(result);
        }
    }
}
