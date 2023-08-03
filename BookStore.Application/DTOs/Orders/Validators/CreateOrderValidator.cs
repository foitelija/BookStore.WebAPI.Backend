using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs.Orders.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrdersRequestDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(p => p.CustomerName).NotEmpty().WithMessage("Имя пользователя должно быть указано");
            RuleFor(p => p.BookIds).NotNull().WithMessage("Должно быть заполнено").Must(NotEqualZero).WithMessage("Выбранных книг не существует.");
        }

        private bool NotEqualZero(List<int> ints)
        {
            return ints.All(i => i != 0);
        }
    }
}
