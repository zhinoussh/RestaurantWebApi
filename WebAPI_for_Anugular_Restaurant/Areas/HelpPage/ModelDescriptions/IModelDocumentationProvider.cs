using System;
using System.Reflection;

namespace WebAPI_for_Anugular_Restaurant.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}