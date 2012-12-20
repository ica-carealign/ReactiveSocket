using FluentAssertions;

using ReactiveSocket.Specifications.Properties;

using TechTalk.SpecFlow;

namespace ReactiveSocket.Specifications.Framework
{
    public abstract class StepBase : TechTalk.SpecFlow.Steps
    {
        protected TObject Retrieve<TObject>(string key)
        {
            object value = ScenarioContext.Current[key];

            value.Should().NotBeNull(Resources.StepBaseRetrieve_Reason_ValueShouldExist, key)
                 .And.BeAssignableTo<TObject>(Resources.StepBaseRetrieve_Reason_ValueShouldBeExpectedType, key);

            return (TObject) value;
        }

        protected void Store<TObject>(TObject value, string key)
        {
            ScenarioContext.Current[key] = value;
        }
    }
}