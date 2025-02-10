using Api.Plumbing;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public abstract class BaseController : Controller
{
    private readonly Bootstrapper _bootstrapper = new();
    protected UseCaseContainer UseCase => _bootstrapper.UseCases;
}