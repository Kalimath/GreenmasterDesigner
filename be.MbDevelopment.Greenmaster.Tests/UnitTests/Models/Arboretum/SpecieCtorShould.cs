﻿using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.Arboretum;
using be.MbDevelopment.Greenmaster.Models.Exceptions;
using be.MbDevelopment.Greenmaster.Models.StaticData;
using be.MbDevelopment.Greenmaster.Models.StaticData.PlantProperties;
using Xunit;
using Xunit.Abstractions;

namespace be.MbDevelopment.Greenmaster.Tests.UnitTests.Models.Arboretum;

public class SpecieCtorShould
{
    
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _validCommonNameNl;
    private readonly string _validScientificName;
    private readonly EnumVDictionary<Language, string> _validCommonNames;
    private readonly PlantProperties _validPlantProperties;
    private readonly PlantDimensions _validPlantDimensions;
    private readonly Language _language = Language.Nl;
    
    public SpecieCtorShould(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _validPlantDimensions = new PlantDimensions(1.5,0.5);
        _validScientificName = "Strelitzia reginae";
        _validCommonNameNl = "Paradijsvogelbloem";
        _validCommonNames = new EnumVDictionary<Language, string>();
        _validPlantProperties = new PlantProperties(false, Lifecycle.Annual);
    }

    [Fact]
    public void SetScientificNameCorrectlyWhenNotNullOrEmpty()
    {
        var validScientificName = "Strelitzia reginae";
        Specie validSpecie = new Specie(validScientificName, _validPlantDimensions);
        Assert.Equal(validScientificName, validSpecie.ScientificName);
    }

    [Fact]
    public void ThrowArgumentExceptionWhenScientificNameEmpty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var badSpecie = new Specie("", _validPlantDimensions);
        });
    }

    [Fact]
    public void SetCommonNamesCorrectlyWhenNotNullOrEmpty()
    {
        _validCommonNames[_language.ToString()] = _validCommonNameNl;
        Specie validSpecie = new Specie(_validScientificName, _validCommonNames, _validPlantProperties, _validPlantDimensions);
        _testOutputHelper.WriteLine(_validCommonNames[_language.ToString()]);
        Assert.Equal(_validCommonNameNl, validSpecie.CommonNames?[_language.ToString()]);
    }

    [Fact]
    public void ThrowArgumentNullExceptionWhenCommonNamesSetEmpty()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            var badSpecie = new Specie(_validScientificName, _validCommonNames, _validPlantProperties, _validPlantDimensions);
            _testOutputHelper.WriteLine(_validCommonNames[_language.ToString()]);
        });
    }
    
    [Fact]
    public void ThrowInvalidDimensionsExceptionWhenPlantDimensionsEmpty()
    {
        Assert.Throws<InvalidDimensionsException>(() =>
        {
            var specie = new Specie(_validScientificName, _validCommonNames, _validPlantProperties, _validPlantDimensions);
            _testOutputHelper.WriteLine(specie.Dimensions.MetricHeight+"");
            Assert.True(specie.Dimensions.MetricHeight>0);
        });
    }

}