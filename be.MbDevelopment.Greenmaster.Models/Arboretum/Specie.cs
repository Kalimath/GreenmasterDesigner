﻿using System.ComponentModel.DataAnnotations;
using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.StaticData;

namespace be.MbDevelopment.Greenmaster.Models.Arboretum;

public class Specie
{
    [MinLength(3)] [MaxLength(20)] public string ScientificName { get; private set; }

    public EnumVDictionary<Language, string>? CommonNames { get; set; }
    public PlantProperties Properties { get; set; }

    public Specie(string scientificName, EnumVDictionary<Language, string> commonNames, PlantProperties properties)
    {
        ScientificName = !string.IsNullOrWhiteSpace(scientificName)
            ? scientificName
            : throw new ArgumentException(nameof(scientificName));
        CommonNames = commonNames;
        Properties = properties;
    }

    public Specie(string scientificName) : this(scientificName, new EnumVDictionary<Language, string>(), null!)
    {
    }
}