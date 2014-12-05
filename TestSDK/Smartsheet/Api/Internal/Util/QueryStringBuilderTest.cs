using NUnit.Framework;
using Smartsheet.Api.Internal.Utility;

namespace TestSDK.Smartsheet.Api.Internal.Util
{
    class QueryStringBuilderTest
    {
        private QueryStringBuilder _builder;
        [SetUp]
        public virtual void SetUp()
        {
            _builder = new QueryStringBuilder();
        }

        [Test]
        public virtual void WhenNoParametersAreAdded_QueryStringIsEmpty()
        {
            //assert
            Assert.True(_builder.QueryString.Length == 0);
        }

        [Test]
        public virtual void AddParamenter_WhenNoParametersWereAdded_QueryStringFirstCharacterIsquestionMark()
        {
            const string parameterName = "testParameter";
            const string parameterValue = "testParameterValue";
            //act
            _builder.AddParameter(parameterName, parameterValue);
            //assert
            Assert.AreEqual(_builder.QueryString[0], '?');
        }

        [Test]
        public virtual void AddParamenter_OneEmptyValueParameter_ParameterNameIsAfterQuestionMark()
        {
            const string parameterName = "testParameter";
            //act
            _builder.AddParameter(parameterName, string.Empty);
            //assert
            Assert.AreEqual(_builder.QueryString.IndexOf(parameterName), 1);
        }

        [Test]
        public virtual void AddParamenter_OneEmptyValueParameterAdded_LastCharacterIsEquals()
        {
            const string parameterName = "testParameter";
            //act
            _builder.AddParameter(parameterName, string.Empty);
            //assert
            Assert.AreEqual(_builder.QueryString[_builder.QueryString.Length - 1], '=');
        }

        [Test]
        public void AddParamenter_NotEmptyValueParameterAdded_CharacterBeforeValueIsEquals()
        {
            const string parameterName = "testParameter";
            const string parameterValue = "testParameterValue";
            //act
            _builder.AddParameter(parameterName, parameterValue);
            //assert
            Assert.AreEqual(_builder.QueryString[_builder.QueryString.IndexOf(parameterValue) - 1], '=');
        }

        [Test]
        public void AddParamenter_NotEmptyValueParameterAdded_ValueIsAtEndOfQueryString()
        {
            const string parameterName = "testParameter";
            const string parameterValue = "testParameterValue";
            //act
            _builder.AddParameter(parameterName, parameterValue);
            //assert
            Assert.AreEqual(_builder.QueryString.IndexOf(parameterValue), _builder.QueryString.Length - parameterValue.Length);
        }
    }
}
