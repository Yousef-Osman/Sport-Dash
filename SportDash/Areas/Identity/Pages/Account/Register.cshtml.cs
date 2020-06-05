using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SportDash.Data;
using SportDash.Models;

namespace SportDash.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;

            roles = _roleManager.Roles.Select(a => new SelectListItem
            {
                Value = a.Name.ToString(),
                Text = a.Name
            }).ToList();

            var lists = new RegistrationLists();

            locations = lists.locations;
            SportTypeOptions = lists.SportTypeOptions;
            BallRentingOptions = lists.availability;
            LockerRoomOptions = lists.availability;
            SafeOptions = lists.availability;
            ToiletOptions = lists.availability;
            ForLadiesOptions = lists.availability;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        [Required]
        [Display(Name = "Create an account as")]
        public string SelectedRole { get; set; }

        public List<SelectListItem> roles { get; set; }
        public List<SelectListItem> locations { get; set; }
        public List<SelectListItem> SportTypeOptions { get; set; }
        public List<SelectListItem> BallRentingOptions { get; set; }
        public List<SelectListItem> LockerRoomOptions { get; set; }
        public List<SelectListItem> SafeOptions { get; set; }
        public List<SelectListItem> ToiletOptions { get; set; }
        public List<SelectListItem> ForLadiesOptions { get; set; }

        public string ReturnUrl { get; set; }


        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            public GamesCategory SportType { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            public string Location { get; set; }
            public bool? BallRenting { get; set; } = false;
            public bool? LockerRoom { get; set; } = false;
            public bool? Safe { get; set; } = false;
            public bool? Toilet { get; set; } = false;
            public bool? ForLadies { get; set; } = false;

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            Input.BallRenting = Input.BallRenting ?? false;
            Input.LockerRoom = Input.LockerRoom ?? false;
            Input.Safe = Input.Safe ?? false;
            Input.Toilet = Input.Toilet ?? false;
            Input.ForLadies = Input.ForLadies ?? false;

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FullName = Input.FullName,
                    Location = Input.Location,
                    SportType = Input.SportType,
                    Category = SelectedRole,
                    BallRenting = Input.BallRenting,
                    LockerRoom = Input.LockerRoom,
                    Safe = Input.Safe,
                    Toilet = Input.Toilet,
                    ForLadies = Input.ForLadies
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    System.Diagnostics.Debug.WriteLine(SelectedRole);

                    var createdUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(createdUser, SelectedRole);

                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}