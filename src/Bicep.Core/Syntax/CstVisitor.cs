// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Bicep.Core.Parsing;

namespace Bicep.Core.Syntax
{
    /// <summary>
    /// Visits a <see href="https://en.wikipedia.org/wiki/Parse_tree">concrete syntax tree (CST)</see>.
    /// </summary>
    public abstract class CstVisitor : SyntaxVisitor
    {
        public override void VisitToken(Token token)
        {
            foreach (var syntaxTrivia in token.LeadingTrivia)
            {
                this.VisitSyntaxTrivia(syntaxTrivia);
            }

            foreach (var syntaxTrivia in token.TrailingTrivia)
            {
                this.VisitSyntaxTrivia(syntaxTrivia);
            }
        }

        public override void VisitSyntaxTrivia(SyntaxTrivia syntaxTrivia)
        {
        }

        public override void VisitSeparatedSyntaxList(SeparatedSyntaxList syntax)
        {
            // visit paired elements in order
            foreach (var (item, token) in syntax.GetPairedElements())
            {
                this.Visit(item);
                this.Visit(token);
            }
        }

        public override void VisitMetadataDeclarationSyntax(MetadataDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Assignment);
            this.Visit(syntax.Value);
        }

        public override void VisitParameterDeclarationSyntax(ParameterDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Type);
            this.Visit(syntax.Modifier);
        }

        public override void VisitParameterDefaultValueSyntax(ParameterDefaultValueSyntax syntax)
        {
            this.Visit(syntax.AssignmentToken);
            this.Visit(syntax.DefaultValue);
        }

        public override void VisitVariableDeclarationSyntax(VariableDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Type);
            this.Visit(syntax.Assignment);
            this.Visit(syntax.Value);
        }

        public override void VisitLocalVariableSyntax(LocalVariableSyntax syntax)
        {
            this.Visit(syntax.Name);
        }

        public override void VisitTargetScopeSyntax(TargetScopeSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Assignment);
            this.Visit(syntax.Value);
        }

        public override void VisitResourceDeclarationSyntax(ResourceDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Type);
            this.Visit(syntax.ExistingKeyword);
            this.Visit(syntax.Assignment);
            this.VisitNodes(syntax.Newlines);
            this.Visit(syntax.Value);
        }

        public override void VisitModuleDeclarationSyntax(ModuleDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Path);
            this.Visit(syntax.Assignment);
            this.VisitNodes(syntax.Newlines);
            this.Visit(syntax.Value);
        }
        public override void VisitTestDeclarationSyntax(TestDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Path);
            this.Visit(syntax.Assignment);
            this.Visit(syntax.Value);
        }
        public override void VisitOutputDeclarationSyntax(OutputDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Type);
            this.Visit(syntax.Assignment);
            this.Visit(syntax.Value);
        }

        public override void VisitAssertDeclarationSyntax(AssertDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Assignment);
            this.Visit(syntax.Value);
        }

        public override void VisitIdentifierSyntax(IdentifierSyntax syntax)
        {
            this.Visit(syntax.Child);
        }

        public override void VisitResourceTypeSyntax(ResourceTypeSyntax syntax)
        {
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Type);
        }

        public override void VisitObjectTypeSyntax(ObjectTypeSyntax syntax)
        {
            this.Visit(syntax.OpenBrace);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseBrace);
        }

        public override void VisitObjectTypePropertySyntax(ObjectTypePropertySyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Key);
            this.Visit(syntax.Colon);
            this.Visit(syntax.Value);
        }

        public override void VisitObjectTypeAdditionalPropertiesSyntax(ObjectTypeAdditionalPropertiesSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Asterisk);
            this.Visit(syntax.Colon);
            this.Visit(syntax.Value);
        }

        public override void VisitTupleTypeSyntax(TupleTypeSyntax syntax)
        {
            this.Visit(syntax.OpenBracket);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseBracket);
        }

        public override void VisitTupleTypeItemSyntax(TupleTypeItemSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Value);
        }

        public override void VisitArrayTypeSyntax(ArrayTypeSyntax syntax)
        {
            this.Visit(syntax.Item);
            this.Visit(syntax.OpenBracket);
            this.Visit(syntax.CloseBracket);
        }

        public override void VisitArrayTypeMemberSyntax(ArrayTypeMemberSyntax syntax)
        {
            this.Visit(syntax.Value);
        }

        public override void VisitUnionTypeSyntax(UnionTypeSyntax syntax)
        {
            this.VisitNodes(syntax.Children);
        }

        public override void VisitUnionTypeMemberSyntax(UnionTypeMemberSyntax syntax)
        {
            this.Visit(syntax.Value);
        }

        public override void VisitTypeDeclarationSyntax(TypeDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Assignment);
            this.Visit(syntax.Value);
        }

        public override void VisitNullableTypeSyntax(NullableTypeSyntax syntax)
        {
            this.Visit(syntax.Base);
            this.Visit(syntax.NullabilityMarker);
        }

        public override void VisitBooleanLiteralSyntax(BooleanLiteralSyntax syntax)
        {
            this.Visit(syntax.Literal);
        }

        public override void VisitStringSyntax(StringSyntax syntax)
        {
            for (var i = 0; i < syntax.Expressions.Length; i++)
            {
                this.Visit(syntax.StringTokens[i]);
                this.Visit(syntax.Expressions[i]);
            }
            this.Visit(syntax.StringTokens.Last());
        }

        public override void VisitProgramSyntax(ProgramSyntax syntax)
        {
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.EndOfFile);
        }

        public override void VisitIntegerLiteralSyntax(IntegerLiteralSyntax syntax)
        {
            this.Visit(syntax.Literal);
        }

        public override void VisitNullLiteralSyntax(NullLiteralSyntax syntax)
        {
            this.Visit(syntax.NullKeyword);
        }

        public override void VisitNoneLiteralSyntax(NoneLiteralSyntax syntax)
        {
            this.Visit(syntax.NoneKeyword);
        }

        public override void VisitSkippedTriviaSyntax(SkippedTriviaSyntax syntax)
        {
            foreach (var element in syntax.Elements)
            {
                this.Visit(element);
            }
        }

        public override void VisitObjectSyntax(ObjectSyntax syntax)
        {
            this.Visit(syntax.OpenBrace);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseBrace);
        }

        public override void VisitObjectPropertySyntax(ObjectPropertySyntax syntax)
        {
            this.Visit(syntax.Key);
            this.Visit(syntax.Colon);
            this.Visit(syntax.Value);
        }

        public override void VisitArraySyntax(ArraySyntax syntax)
        {
            this.Visit(syntax.OpenBracket);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseBracket);
        }

        public override void VisitArrayItemSyntax(ArrayItemSyntax syntax)
        {
            this.Visit(syntax.Value);
        }

        public override void VisitIfConditionSyntax(IfConditionSyntax syntax)
        {
            this.Visit(syntax.Keyword);
            this.Visit(syntax.ConditionExpression);
            this.Visit(syntax.Body);
        }

        public override void VisitForSyntax(ForSyntax syntax)
        {
            this.Visit(syntax.OpenSquare);
            this.VisitNodes(syntax.OpenNewlines);
            this.Visit(syntax.ForKeyword);
            this.Visit(syntax.VariableSection);
            this.Visit(syntax.InKeyword);
            this.Visit(syntax.Expression);
            this.Visit(syntax.Colon);
            this.Visit(syntax.Body);
            this.VisitNodes(syntax.CloseNewlines);
            this.Visit(syntax.CloseSquare);
        }

        public override void VisitVariableBlockSyntax(VariableBlockSyntax syntax)
        {
            this.Visit(syntax.OpenParen);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseParen);
        }

        public override void VisitTernaryOperationSyntax(TernaryOperationSyntax syntax)
        {
            this.Visit(syntax.ConditionExpression);
            this.VisitNodes(syntax.NewlinesBeforeQuestion);
            this.Visit(syntax.Question);
            this.Visit(syntax.TrueExpression);
            this.VisitNodes(syntax.NewlinesBeforeColon);
            this.Visit(syntax.Colon);
            this.Visit(syntax.FalseExpression);
        }

        public override void VisitBinaryOperationSyntax(BinaryOperationSyntax syntax)
        {
            this.Visit(syntax.LeftExpression);
            this.Visit(syntax.OperatorToken);
            this.Visit(syntax.RightExpression);
        }

        public override void VisitUnaryOperationSyntax(UnaryOperationSyntax syntax)
        {
            this.Visit(syntax.OperatorToken);
            this.Visit(syntax.Expression);
        }

        public override void VisitArrayAccessSyntax(ArrayAccessSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.OpenSquare);
            this.Visit(syntax.SafeAccessMarker);
            this.Visit(syntax.FromEndMarker);
            this.Visit(syntax.IndexExpression);
            this.Visit(syntax.CloseSquare);
        }

        public override void VisitPropertyAccessSyntax(PropertyAccessSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.Dot);
            this.Visit(syntax.SafeAccessMarker);
            this.Visit(syntax.PropertyName);
        }

        public override void VisitResourceAccessSyntax(ResourceAccessSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.DoubleColon);
            this.Visit(syntax.ResourceName);
        }

        public override void VisitParenthesizedExpressionSyntax(ParenthesizedExpressionSyntax syntax)
        {
            this.Visit(syntax.OpenParen);
            this.Visit(syntax.Expression);
            this.Visit(syntax.CloseParen);
        }

        public override void VisitFunctionCallSyntax(FunctionCallSyntax syntax)
        {
            this.Visit(syntax.Name);
            this.Visit(syntax.OpenParen);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseParen);
        }

        public override void VisitInstanceFunctionCallSyntax(InstanceFunctionCallSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.Dot);
            this.Visit(syntax.Name);
            this.Visit(syntax.OpenParen);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseParen);
        }

        public override void VisitFunctionArgumentSyntax(FunctionArgumentSyntax syntax)
        {
            this.Visit(syntax.Expression);
        }

        public override void VisitVariableAccessSyntax(VariableAccessSyntax syntax)
        {
            this.Visit(syntax.Name);
        }

        public override void VisitDecoratorSyntax(DecoratorSyntax syntax)
        {
            this.Visit(syntax.At);
            this.Visit(syntax.Expression);
        }

        public override void VisitMissingDeclarationSyntax(MissingDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
        }

        public override void VisitExtensionDeclarationSyntax(ExtensionDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.SpecificationString);
            this.Visit(syntax.WithClause);
            this.Visit(syntax.AsClause);
        }

        public override void VisitExtensionConfigAssignmentSyntax(ExtensionConfigAssignmentSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Alias);
            this.Visit(syntax.WithClause);
        }

        public override void VisitExtensionWithClauseSyntax(ExtensionWithClauseSyntax syntax)
        {
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Config);
        }

        public override void VisitAliasAsClauseSyntax(AliasAsClauseSyntax syntax)
        {
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Alias);
        }

        public override void VisitParameterAssignmentSyntax(ParameterAssignmentSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Assignment);
            this.Visit(syntax.Value);
        }

        public override void VisitUsingDeclarationSyntax(UsingDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Path);
        }

        public override void VisitExtendsDeclarationSyntax(ExtendsDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Path);
        }

        public override void VisitLambdaSyntax(LambdaSyntax syntax)
        {
            this.Visit(syntax.VariableSection);
            this.Visit(syntax.Arrow);
            this.VisitNodes(syntax.NewlinesBeforeBody);
            this.Visit(syntax.Body);
        }

        public override void VisitNonNullAssertionSyntax(NonNullAssertionSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.AssertionOperator);
        }

        public override void VisitTypedVariableBlockSyntax(TypedVariableBlockSyntax syntax)
        {
            this.Visit(syntax.OpenParen);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseParen);
        }

        public override void VisitTypedLocalVariableSyntax(TypedLocalVariableSyntax syntax)
        {
            this.Visit(syntax.Name);
            this.Visit(syntax.Type);
        }

        public override void VisitTypedLambdaSyntax(TypedLambdaSyntax syntax)
        {
            this.Visit(syntax.VariableSection);
            this.Visit(syntax.ReturnType);
            this.Visit(syntax.Arrow);
            this.VisitNodes(syntax.NewlinesBeforeBody);
            this.Visit(syntax.Body);
        }

        public override void VisitFunctionDeclarationSyntax(FunctionDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Name);
            this.Visit(syntax.Lambda);
        }

        public override void VisitCompileTimeImportDeclarationSyntax(CompileTimeImportDeclarationSyntax syntax)
        {
            this.VisitNodes(syntax.LeadingNodes);
            this.Visit(syntax.Keyword);
            this.Visit(syntax.ImportExpression);
            this.Visit(syntax.FromClause);
        }

        public override void VisitImportedSymbolsListSyntax(ImportedSymbolsListSyntax syntax)
        {
            this.Visit(syntax.OpenBrace);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseBrace);
        }

        public override void VisitImportedSymbolsListItemSyntax(ImportedSymbolsListItemSyntax syntax)
        {
            this.Visit(syntax.OriginalSymbolName);
            this.Visit(syntax.AsClause);
        }

        public override void VisitWildcardImportSyntax(WildcardImportSyntax syntax)
        {
            this.Visit(syntax.Wildcard);
            this.Visit(syntax.AliasAsClause);
        }

        public override void VisitCompileTimeImportFromClauseSyntax(CompileTimeImportFromClauseSyntax syntax)
        {
            this.Visit(syntax.Keyword);
            this.Visit(syntax.Path);
        }

        public override void VisitParameterizedTypeInstantiationSyntax(ParameterizedTypeInstantiationSyntax syntax)
        {
            this.Visit(syntax.Name);
            this.Visit(syntax.OpenChevron);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseChevron);
        }

        public override void VisitInstanceParameterizedTypeInstantiationSyntax(InstanceParameterizedTypeInstantiationSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.Dot);
            this.Visit(syntax.PropertyName);
            this.Visit(syntax.OpenChevron);
            this.VisitNodes(syntax.Children);
            this.Visit(syntax.CloseChevron);
        }

        public override void VisitParameterizedTypeArgumentSyntax(ParameterizedTypeArgumentSyntax syntax)
        {
            this.Visit(syntax.Expression);
        }

        public override void VisitTypePropertyAccessSyntax(TypePropertyAccessSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.Dot);
            this.Visit(syntax.PropertyName);
        }

        public override void VisitTypeAdditionalPropertiesAccessSyntax(TypeAdditionalPropertiesAccessSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.Dot);
            this.Visit(syntax.Asterisk);
        }

        public override void VisitTypeArrayAccessSyntax(TypeArrayAccessSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.OpenSquare);
            this.Visit(syntax.IndexExpression);
            this.Visit(syntax.CloseSquare);
        }

        public override void VisitTypeItemsAccessSyntax(TypeItemsAccessSyntax syntax)
        {
            this.Visit(syntax.BaseExpression);
            this.Visit(syntax.OpenSquare);
            this.Visit(syntax.Asterisk);
            this.Visit(syntax.CloseSquare);
        }

        public override void VisitTypeVariableAccessSyntax(TypeVariableAccessSyntax syntax)
        {
            this.Visit(syntax.Name);
        }

        public override void VisitStringTypeLiteralSyntax(StringTypeLiteralSyntax syntax)
        {
            for (int i = 0; i < syntax.StringTokens.Length + syntax.Expressions.Length; i++)
            {
                this.Visit(i % 2 == 0 ? syntax.StringTokens[i / 2] : syntax.Expressions[i / 2]);
            }
        }

        public override void VisitIntegerTypeLiteralSyntax(IntegerTypeLiteralSyntax syntax)
        {
            this.Visit(syntax.Literal);
        }

        public override void VisitBooleanTypeLiteralSyntax(BooleanTypeLiteralSyntax syntax)
        {
            this.Visit(syntax.Literal);
        }

        public override void VisitNullTypeLiteralSyntax(NullTypeLiteralSyntax syntax)
        {
            this.Visit(syntax.NullKeyword);
        }

        public override void VisitUnaryTypeOperationSyntax(UnaryTypeOperationSyntax syntax)
        {
            this.Visit(syntax.OperatorToken);
            this.Visit(syntax.Expression);
        }

        public override void VisitNonNullableTypeSyntax(NonNullableTypeSyntax syntax)
        {
            this.Visit(syntax.Base);
            this.Visit(syntax.NonNullabilityMarker);
        }

        public override void VisitParenthesizedTypeSyntax(ParenthesizedTypeSyntax syntax)
        {
            this.Visit(syntax.OpenParen);
            this.Visit(syntax.Expression);
            this.Visit(syntax.CloseParen);
        }

        public override void VisitSpreadExpressionSyntax(SpreadExpressionSyntax syntax)
        {
            this.Visit(syntax.Ellipsis);
            this.Visit(syntax.Expression);
        }
    }
}
