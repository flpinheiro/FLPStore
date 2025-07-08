using FLPStore.Core.Models.Shared;

namespace FLPStore.Tests.Fixtures;

internal class BasicValueObjectFixture<TClass> : BasicFixture<TClass> where TClass : ValueObject;
