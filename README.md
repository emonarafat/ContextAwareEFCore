# ContextAwareEFCore  

## Behavior Altering DB Context in EF Core  

⛔ Tired of rigid repositories and generic services? There’s a smarter, context-aware way.  

Entity Framework Core lets you customize behavior based on the consuming context—without messy workarounds or code duplication.  

### ▸ Scenario 1: An admin endpoint wants all records, but a user should only see their own.  
Use scoped services or constructor parameters to drive query logic.  

### ▸ Scenario 2: Inject a lightweight ContextInfo service that your DbContext can read to shape behavior.  

### ▸ Scenario 3: Add filters or conventions to adjust soft deletes, audit info, or tenant filters.  

✨ **Bonus**: No need to split models or pollute logic with if-else blocks.  

Your DbContext can now adapt dynamically—making your architecture cleaner, testable, and more modular.  

**Context-Aware EF is here. Use it smart.**




