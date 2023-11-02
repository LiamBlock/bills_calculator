using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HouseholdBillsCalculator.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public decimal Person1Income { get; set; }

        [BindProperty]
        public decimal Person2Income { get; set; }

        [BindProperty]
        public decimal Rent { get; set; }

        [BindProperty]
        public decimal Electricity { get; set; }

        [BindProperty]
        public decimal CouncilTax { get; set; }

        [BindProperty]
        public decimal Water { get; set; }

        [BindProperty]
        public decimal Broadband { get; set; }

        public void OnGet()
        {
            // This method is called when the page is initially requested.
            // You can perform any necessary setup here.
        }

        public IActionResult OnPost()
        {
            decimal totalIncome = Person1Income + Person2Income;
            decimal totalExpenses = Rent + Electricity + CouncilTax + Water + Broadband;

            decimal person1_share = (Person1Income / totalIncome) * 100;
            decimal person2_share = (Person2Income / totalIncome) * 100;

            decimal Person1Pays = totalExpenses * (person1_share / 100);
            decimal Person2Pays = totalExpenses * (person2_share / 100);

            TempData["Person1Share"] = Math.Round(person1_share, 2).ToString();
            TempData["Person2Share"] = Math.Round(person2_share, 2).ToString();
            TempData["Person1Pays"] = Math.Round(Person1Pays, 2).ToString();
            TempData["Person2Pays"] = Math.Round(Person2Pays, 2).ToString();

            return RedirectToPage("/Results");
        }
    }
}