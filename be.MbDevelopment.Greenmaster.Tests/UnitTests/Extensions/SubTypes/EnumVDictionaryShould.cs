using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Tests.TestData;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Extensions.SubTypes;

public class EnumDirectoryShould
{
    private readonly string _testValue;
    private EnumVDictionary<TestEnum, string> _validEnumVDictionary;

    public EnumDirectoryShould()
    {
        _testValue = "test if it works";
        _validEnumVDictionary = new EnumVDictionary<TestEnum, string>();
    }

    [Fact]
    public void InitiateTEnumKeyValuePairsOnCreation()
    {
        if (_validEnumVDictionary == null) throw new ArgumentNullException(nameof(_validEnumVDictionary));
        Assert.True(_validEnumVDictionary.ContainsKey(TestEnum.Test1.ToString()));
        Assert.True(_validEnumVDictionary.ContainsKey(TestEnum.Tester.ToString()));
        Assert.True(_validEnumVDictionary.ContainsKey(TestEnum.Testing.ToString()));
    }

    [Fact]
    public void SetValueToNullWhenRemoveIsCalled()
    {
        var createdDir = new EnumVDictionary<TestEnum, string> { { TestEnum.Tester, _testValue } };
        createdDir.Remove(eKey: TestEnum.Tester);
        Assert.Null(createdDir[TestEnum.Tester.ToString()]);
    }

    [Fact]
    public void AddWhenKeyIsTypeEnumAndAlreadyExists()
    {
        _validEnumVDictionary.Add(TestEnum.Tester, _testValue);
        Assert.Null(_validEnumVDictionary[TestEnum.Test1.ToString()]);
        Assert.Equal(_testValue, _validEnumVDictionary[TestEnum.Tester.ToString()]);
        Assert.Null(_validEnumVDictionary[TestEnum.Testing.ToString()]);
    }
    
    /*[Fact]
    public void ReturnTrueWhenContainsKey()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public void ReturnFalseWhenNotContainsKey()
    {
        throw new NotImplementedException();
    }
    
    [Fact]
    public void ReturnTrueWhenContainsValue()
    {
        _validEnumVDictionary.ContainsValue()
    }
    
    [Fact]
    public void ReturnFalseWhenNotContainsValue()
    {
        throw new NotImplementedException();
    }*/

   
    
}