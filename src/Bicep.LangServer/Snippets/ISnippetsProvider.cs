// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Bicep.Core.Features;
using Bicep.Core.Resources;
using Bicep.Core.TypeSystem;
using Bicep.Core.TypeSystem.Types;

namespace Bicep.LanguageServer.Snippets
{
    public interface ISnippetsProvider
    {
        IEnumerable<Snippet> GetNestedResourceDeclarationSnippets(ResourceTypeReference resourceTypeReference);

        IEnumerable<Snippet> GetTopLevelNamedDeclarationSnippets();

        IEnumerable<Snippet> GetModuleBodyCompletionSnippets(TypeSymbol typeSymbol);

        IEnumerable<Snippet> GetTestBodyCompletionSnippets(TypeSymbol typeSymbol);

        IEnumerable<Snippet> GetObjectBodyCompletionSnippets(TypeSymbol typeSymbol);

        IEnumerable<Snippet> GetResourceBodyCompletionSnippets(ResourceType resourceType, bool isExistingResource, bool isResourceNested);

        IEnumerable<Snippet> GetIdentitySnippets(bool isResource);
    }
}
