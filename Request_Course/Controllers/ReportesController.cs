using Microsoft.AspNetCore.Mvc;
using Request_Course.VM;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace Request_Course.Controllers
{
    public class ReportesController : Controller
    {

        public ReportesController()
        {
        //    StiLicense.LoadFromString("6vJhGtLLLz2GNviWmUTrhSqnOItdDwjBylQzQcAOiHkcgIvwL0jnpsDqRpWg5FI5kt2G7A0tYIcUygBh1sPs7rE7BAeUEkpkjUKhl6/j24S6yxsIWZIRjJksEoLVUjBueVKUbrngXOqKSPJ8HE3n1pShqAKcqrYW8MlF8pB4nnRnYzLWJ/P+/p8zFGywvfSWm7L6hGvJFWozdlx5wLTj4K5UuclS2XfPNkIDrt7BY5X2KVdt42NBLZbM5RdUB8iJFobpp0HzoKZI8TSn++9s0y2cM/uGn0zHRcz/b8P/PiiOJkRkm0XlFrXG19KuA6eBAUfWiHYAgTMZq2UCyOdCbDZEcF8SqCGjboFuTyI7OHTQ4PVFQY8uEmsqhes9jqiz7u7Ts7Ndy88rVAe10GiHrBdyAGf4AR4G9DFrA10fnTGIVLixX8GpNTGgsLFIOf+IQOUvdcV39PeCf2JA2vEhSqbiaiftgGwxxgbc8ENPXijj+wYztDzMBeTJUwZBheNLcD2Rqwrc//HYvbuG6aZSjPCA5DvD3QJMvdBdHM3HWvlyU0tN6xVAiECAvWQdSOks");
        }

        public async Task<IActionResult> Report()
        {
            return View();
        }


        public async Task<IActionResult> Print()
        {
            StiReport report = new StiReport();
            report.Load("Reports/Report.mrt");
            DorehDarkhastiReportVM model = new DorehDarkhastiReportVM()
            {
                Name = "ali",
                Phone = "0190",
                RequesterName = "Ali"
            };
            report.RegData("dt", model);
            return await StiNetCoreViewer.GetReportResultAsync(this,report);

        }

        public async Task<IActionResult> ViewEvent()
        {
            return await StiNetCoreViewer.ViewerEventResultAsync(this);
        }

    }
}
