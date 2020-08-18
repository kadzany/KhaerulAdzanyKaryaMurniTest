using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto
{
    public class SetTodoPercentCompleteDto
    {
        public int Id { get; set; }
        public decimal PercentComplete { get; set; }
    }
}
