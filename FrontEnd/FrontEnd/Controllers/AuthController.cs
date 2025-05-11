using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Format date to match expected ISO 8601 format
                var payload = new
                {
                    email = model.Email,
                    name = model.Name,
                    password = model.Password,
                    confirmPassword = model.ConfirmPassword,
                    phoneNumber = model.PhoneNumber,
                    IDNumber = model.IDNumber,  // Note the capitalization
                    IDPhoto = string.Empty,     // Empty for now
                    PersonPhoto = string.Empty, // Empty for now
                    dateOfBirth = model.DateOfBirth,
                    location = model.Location,
                    gender = model.Gender,
                    role = (int)model.Role
                };

                // Serialize to JSON
                var jsonContent = JsonConvert.SerializeObject(payload);
                Console.WriteLine("Request payload: " + jsonContent);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send request to API
                var response = await _httpClient.PostAsync("https://localhost:44396/api/auth/register", content);

                // Read response
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: " + responseContent);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Registration successful!";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    try
                    {
                        var errorResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

                        if (errorResponse != null)
                        {
                            // Check if there's a specific error message
                            string errorMessage = errorResponse.message?.ToString() ?? "Registration failed";
                            ModelState.AddModelError("", errorMessage);

                            // Check for field-specific errors
                            if (errorResponse.errors != null)
                            {
                                foreach (var error in errorResponse.errors)
                                {
                                    string fieldName = error.Name;
                                    var errorValue = error.Value;

                                    if (errorValue != null && errorValue.Count > 0)
                                    {
                                        ModelState.AddModelError(fieldName, errorValue[0].ToString());
                                    }
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Registration failed: " + responseContent);
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("", "Registration failed: " + responseContent);
                    }

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View(model);
            }
        }
    }
}