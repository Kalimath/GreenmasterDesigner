using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Tests.TestData;
using Xunit;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Extensions.SubTypes;

public class EnumDirectoryShould
{
    private readonly string _testValue;

    public EnumDirectoryShould()
    {
        _testValue = "test if it works";
    }

    [Fact]
    public void InitiateTEnumKeyValuePairsOnCreation()
    {
        var createdDir = new EnumVDictionary<TestEnum, string>();
        if (createdDir == null) throw new ArgumentNullException(nameof(createdDir));
        Assert.True(createdDir.ContainsKey(TestEnum.Test1.ToString()));
        Assert.True(createdDir.ContainsKey(TestEnum.Tester.ToString()));
        Assert.True(createdDir.ContainsKey(TestEnum.Testing.ToString()));
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
        var createdDir = new EnumVDictionary<TestEnum, string> { { TestEnum.Tester, _testValue } };
        Assert.Null(createdDir[TestEnum.Test1.ToString()]);
        Assert.Equal(_testValue, createdDir[TestEnum.Tester.ToString()]);
        Assert.Null(createdDir[TestEnum.Testing.ToString()]);
    }
    
    [Fact]
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
        throw new NotImplementedException();
    }
    
    [Fact]
    public void ReturnFalseWhenNotContainsValue()
    {
        throw new NotImplementedException();
    }

   
    
}