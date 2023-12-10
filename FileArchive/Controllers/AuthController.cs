using System.Threading.Tasks;
using FileArchive.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace FileArchive.Controllers;

public class AuthController : Controller
{
    private readonly SignInManager<FileArchiveUser> _signInManager;
    private readonly UserManager<FileArchiveUser> _userManager;

    public AuthController (UserManager<FileArchiveUser> userManager, SignInManager<FileArchiveUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public ActionResult LogIn () => View(new LogInData());

    [HttpGet]
    public ActionResult SighUp () => View(new SignUpData());

    [HttpPost]
    public async Task<ActionResult> LogIn (LogInData data)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Wrong input data");
            return View(data);
        }

        var user = await _userManager.FindByEmailAsync(data.EMail);

        if (user == null)
        {
            await _signInManager.SignOutAsync();
            ModelState.AddModelError("", "User with e-mail is not exists");
            return View(data);
        }

        var result = await _signInManager.PasswordSignInAsync(user, data.Password, false, false);

        if (result.Succeeded)
            return RedirectToAction("OverView", "Profile");

        ModelState.AddModelError("", "Wrong login or password");
        return View(data);
    }

    [HttpPost]
    public async Task<ActionResult> SighUp (SignUpData signUpData)
    {
        var user = await _userManager.FindByEmailAsync(signUpData.EMail);
        if (user != null)
        {
            ModelState.AddModelError("", "User with this name is already exists");
            return View(signUpData);
        }

        var result = await _userManager.CreateAsync(
            new FileArchiveUser { 
                UserName = signUpData.EMail, 
                Email = signUpData.EMail, 
                Name = signUpData.EMail,
            }, signUpData.Password);


        if (result.Succeeded)
        {
            var createdUser = await _userManager.FindByEmailAsync(signUpData.EMail);
            if ((await _signInManager.PasswordSignInAsync(createdUser!, signUpData.Password, false, false)).Succeeded)
                return RedirectToAction("OverView", "Profile");
        }

        foreach (var identityError in result.Errors)
            ModelState.AddModelError("", identityError.Description);

        return View(signUpData);
    }

    public async Task<IActionResult> SighOut ()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}