using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string action, int a, int b)
        {

        }
        public void OnPost(string action, int firstNumber, int secondNumber)
        {
            if (action == "add")
            {
                ViewData["Result"] = firstNumber + secondNumber;
            }
            else if (action == "subtract")
            {
                ViewData["result"] = firstNumber - secondNumber;
            }
            else if (action == "multiply")
            {
                ViewData["result"] = firstNumber * secondNumber;
            }
            else if (action == "divide")
            {
                if (secondNumber != 0)
                {
                    ViewData["Result"] = (double)firstNumber / secondNumber;
                }
                else
                {
                    ViewData["Result"] = "Cannot divide by zero";
                }
            }
            else if (action == "root")
            {
                if (secondNumber == 0)
                {
                    ViewData["Result"] = "Root value cannot be zero";
                }
                else if (firstNumber < 0 && secondNumber % 2 == 0)
                {
                    ViewData["Result"] = "Cannot take even root of a negative number";
                }
                else
                {
                    double result = Math.Pow(firstNumber, 1.0 / secondNumber);
                    ViewData["Result"] = result;
                }
            }
            else
            {
                ViewData["Result"] = "Invalid operation";
            }
        }
    }
}
