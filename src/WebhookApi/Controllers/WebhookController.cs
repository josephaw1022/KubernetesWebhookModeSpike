
using Microsoft.AspNetCore.Mvc;

namespace WebhookApi.Controllers;

[ApiController]
[Route("api/webhook")]
public class WebhookController(ILogger<WebhookController> logger) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> PostAsync()
    {

        var request = await new StreamReader(Request.Body).ReadToEndAsync();

        logger.LogInformation("Received webhook request: {request}", request);

        // Process the webhook request here

        // Construct a minimal response to approve all requests
        var response = new
        {
            apiVersion = "admission.k8s.io/v1",
            kind = "AdmissionReview",
            response = new
            {
                uid = "unique-id-here", // Extract this from the received request if necessary
                allowed = true
            }
        };

        return Ok(response);

    }
}