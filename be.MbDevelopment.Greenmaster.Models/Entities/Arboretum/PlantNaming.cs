﻿using be.MbDevelopment.Greenmaster.Extensions.SubTypes;
using be.MbDevelopment.Greenmaster.Models.StaticData;

namespace be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;

public class PlantNaming
{
    public PlantNaming(string genus, string specie, EnumVDictionary<Language, string> common)
    {
        Genus = !string.IsNullOrWhiteSpace(genus)
            ? genus
            : throw new ArgumentException("Given Genus-name is not valid");

        Specie = !string.IsNullOrWhiteSpace(specie)
            ? specie
            : throw new ArgumentException("Given Genus-name is not valid");
        Common = common;
    }

    public string Genus { get; }
    public string Specie { get; }
    public virtual EnumVDictionary<Language, string> Common { get; }

    public string GetScientificName()
    {
        return $"{Genus} {Specie}";
    }
}