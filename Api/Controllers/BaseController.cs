using Api.Plumbing;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public abstract class BaseController : Controller
{
    private readonly Bootstrapper _bootstrapper;
    protected UseCaseContainer UseCase => _bootstrapper.UseCases;

    protected BaseController()
    {
        _bootstrapper = new Bootstrapper();
    }
}