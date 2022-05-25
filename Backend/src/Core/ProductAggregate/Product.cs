using Ardalis.GuardClauses;
using Shared;
using Shared.Interfaces;
namespace Core.ProductAggregate;

public class Product : BaseEntity, IAggregateRoot
{
    //Relations
    public Guid ShopId { get; private set; }
    public Shop Shop { get; private set; } = default!;
    
    public Guid BrandId { get; private set; }
    public Brand Brand { get; private set; } = default!;
    
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = default!;
    
    
    
    // Product settings
    private readonly List<ProductVariant> _productVariants = new();
    public IReadOnlyCollection<ProductVariant> ProductVariants => _productVariants.AsReadOnly();
    
    private readonly List<ProductOption> _productOptions = new();
    public IReadOnlyCollection<ProductOption> ProductOptions => _productOptions.AsReadOnly();
    
    private readonly List<ProductImage> _productImages = new();
    public IReadOnlyCollection<ProductImage> ProductImages => _productImages.AsReadOnly();
    
    
    
    // Properties
    public string Title { get; private set; }
    public string Description { get; private set; }
    public ProductState State { get; private set; }
    
    
    
    // Constructors
    private Product(string title, string description)
    {
        Title = Guard.Against.NullOrEmpty(title, nameof(title));
        Description = Guard.Against.NullOrEmpty(description, nameof(description));
        State = ProductState.Active;
    }
    
    private Product(string title, string description, Brand brand, Category category, Shop shop) : this(title, description)
    {
        Guard.Against.Null(brand, nameof(brand));
        Guard.Against.Null(category, nameof(category));
        Guard.Against.Null(shop, nameof(shop));
        
        brand.AddProduct(this);
        category.AddProduct(this);
        shop.AddProduct(this);
    }
    
    public Product(string title, string description, Brand brand, Category category, Shop shop, ProductVariant productVariant)
        :this(title, description, brand, category, shop)
    {
        Guard.Against.Null(productVariant, nameof(productVariant));
        AddProductVariant(productVariant);
    }

    public Product(string title, string description, Brand brand, Category category, Shop shop, List<ProductVariant> productVariants)
        :this(title, description, brand, category,shop)
    {
        AddProductVariant(productVariants);
    }
    
    
    
    
    
    // Adding
    public void AddProductVariant(ProductVariant productVariant)
    {
        Guard.Against.Null(productVariant);

        // If variant is Master Variant
        if (_productVariants.Count == 1 && !_productVariants.First().HasProductOptionValues()) _productVariants.Clear();
        
        AddProductOption(productVariant.ProductOptionValues.ToList());

        if (HasProductVariant(productVariant)) return;

        productVariant.SetProduct(this);
        _productVariants.Add(productVariant);
    }
    
    public void AddProductVariant(List<ProductVariant> productVariants)
    {
        foreach (var productVariant in productVariants)
        {
            AddProductVariant(productVariant);
        }
    }
    
    private void AddProductOption(ProductOption productOption)
    {
        Guard.Against.Null(productOption);
        
        productOption.SetProduct(this);
        
        if (HasProductOption(productOption)) return;
        _productOptions.Add(productOption);
    }
    
    private void AddProductOption(List<ProductOptionValue> productOptionValues)
    {
        foreach (var optionValue in productOptionValues)
        {
            if (optionValue.ProductOption == null) throw new Exception("productOption is null");
           
            AddProductOption(optionValue.ProductOption);
        }
    }

    public void AddProductImage(ProductImage productImage)
    {
        Guard.Against.Null(productImage);
        productImage.SetProduct(this);
        _productImages.Add(productImage);
    }
    
    public void AddProductImage(List<ProductImage> productImages)
    {
        foreach (var productImage in productImages)
        {
            AddProductImage(productImage);
        }
    }


    
    
    // Setters
    public void SetShop(Shop shop)
    {
        Guard.Against.Null(shop);
        Shop = shop;
        ShopId = shop.Id;
    }
    
    public void SetCategory(Category category)
    {
        Guard.Against.Null(category);
        Category = category;
        CategoryId = category.Id;
    }
    
    public void SetBrand(Brand brand)
    {
        Guard.Against.Null(brand);
        Brand = brand;
        BrandId = brand.Id;
    }

    public void SetState(ProductState newProductState)
    {
        Guard.Against.EnumOutOfRange(newProductState, nameof(ProductState));
        State = newProductState;
    }
    
    
    
    // Has
    public bool HasProductVariant(ProductVariant productVariant)
    {
        Guard.Against.Null(productVariant);
        return _productVariants.Find(variant => variant.Id == productVariant.Id) != null;
    }
    
    public bool HasProductOption(ProductOption productOption)
    {
        Guard.Against.Null(productOption);
        return _productOptions.Find(option => option.Id == productOption.Id) != null;
    }
}
