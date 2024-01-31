// See https://aka.ms/new-console-template for more information
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;


public class AbstractFactorty
{
    static void Main(string[] args)
    {
        var b = new ElectricalProduct(null, null);

        var c = new DeprecatedProduct<ElectricalProduct>(null, null, b);


    }
}



public enum GuidSeeds { UNDEFINED, DEPRECATED, ElectricalProduct, WoodProduct, AnimalProduct, HumanFriendlyProduct }


class GUID
{
    public GUID(GuidSeeds? seed = GuidSeeds.UNDEFINED)
    {
        if(seed.HasValue)
        {
            this.GuidSeed = seed.ToString();
            this.Guid = GenerateGuid(this.RandomValue(seed.ToString()).ToString());
        }
    }

    private string GuidSeed;
    private string _Guid;

    public string Guid
    {
        get { 

            if(this._Guid.StartsWith(this.GuidSeed))
            {
                return this._Guid;
            }
            throw new ArgumentOutOfRangeException(nameof(this._Guid) + "is not current type");
        }
        set { 
            this.Guid = value;
        }
    }

    public string GenerateGuid(string s)
    {
        return this.GuidSeed +"-"+ s;
    }

    private uint RandomValue(string guidSeed)
    {
        uint guid = ((uint)Random.Shared.Next());
        int iterator = 32;
        foreach(var x in guidSeed)
        {
            if(iterator < 32)
            {
                guid ^= (uint)x << iterator;

                iterator = iterator - 8;
            }
        }
        return guid;
    }
}

abstract class Product
{
    private GUID _GUID;

    public List<GUID> ProductInterSectionGUIDs { get; set; } = new List<GUID>();

    public GUID GUID
    {
        get { return _GUID; }
        set { if (value is GUID)
            {
                this._GUID = value;
            }
            else throw new ArgumentException(nameof(GUID) + "wrong InputVALUE");
        }
    }

    public override string ToString()
    {
        string all = "";
        foreach (var i in this.ProductInterSectionGUIDs)
        {
            all = $":::InterSecting: {i}";
        }
        return $"GUID:: {this.GUID}::" + all;
    }

    public Product(GUID? mainGuid, IEnumerable<GUID>? intersecting)
    {
        if(mainGuid is null) this.GUID = new GUID();
        else this.GUID = mainGuid;
        if (intersecting is null)
        {
            this.ProductInterSectionGUIDs.Add(this.GUID);
        }
        else this.ProductInterSectionGUIDs.AddRange(intersecting);
    }
}

class ElectricalProduct : Product
{
    public ElectricalProduct(GUID? mainGuid, IEnumerable<GUID>? intersecting) : base(mainGuid, intersecting)
    {
    }
}

class WoodProduct : Product
{
    public WoodProduct(GUID? mainGuid, IEnumerable<GUID>? intersecting) : base(mainGuid, intersecting)
    {
    }
}

class AnimalProduct : Product
{
    public AnimalProduct(GUID? mainGuid, IEnumerable<GUID>? intersecting) : base(mainGuid, intersecting)
    {
    }
}

class HumanFriendlyProduct : Product
{
    public HumanFriendlyProduct(GUID? mainGuid, IEnumerable<GUID>? intersecting) : base(mainGuid, intersecting)
    {
    }
}


class DeprecatedProduct<T> : Product where T : Product
{
    private T Value { get; set; }

    public DeprecatedProduct(GUID? mainGuid, IEnumerable<GUID>? intersecting) : base(mainGuid, intersecting)
    {
    }

    public DeprecatedProduct(GUID? mainGuid, IEnumerable<GUID>? intersecting, T value) : base(value.GUID, value.ProductInterSectionGUIDs)
    {
        value = this.Value;
    }
}

class UndefinedProduct<T> : Product where T : Product
{
    private T Value { get; set; }

    public UndefinedProduct(GUID? mainGuid, IEnumerable<GUID>? intersecting) : base(mainGuid, intersecting)
    {

    }
    
    public UndefinedProduct(GUID? mainGuid, IEnumerable<GUID> intersecting, T value) : base(value.GUID, value.ProductInterSectionGUIDs)
    {
        this.Value = value;
    }
}
 
abstract class ProductFactory
{ 
    
}

