using CatchDotNet.Core;

namespace CatchDotNet.WebApi.Features.Cases.Exceptions;

public static class CaseExceptions
{
    public static readonly Error ExistCategory = new("CaseService.ExistCategory",
        "The category already exist!");
}