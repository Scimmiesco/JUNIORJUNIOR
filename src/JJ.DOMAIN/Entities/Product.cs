namespace JJ.DOMAIN.Entities
{
    public class Product
    {
        private const string UrlPlaceHolder = "https://placehold.co/";

        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        private Product() { }
        public Product(string name, decimal price, string imageUrl)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

            if (price <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.", nameof(price));

            ValidateImageUrl(imageUrl);

            ChangeName(name);
            UpdatePrice(price);

            if (string.IsNullOrEmpty(imageUrl))
                SetDefaultImage();
            else
                AddOrChangeImage(imageUrl);
        }
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("O novo preço deve ser maior que zero.", nameof(newPrice));

            Price = newPrice;
        }

        public void AddOrChangeImage(string imageUrl)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(imageUrl, nameof(imageUrl));

            ValidateImageUrl(imageUrl);

            ImageUrl = imageUrl;
        }

        private static void ValidateImageUrl(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl) && !imageUrl.StartsWith(UrlPlaceHolder))
                throw new ArgumentException("A imagem deve vir do site 'https://placehold.co/'", nameof(imageUrl));
        }
        public void RemoveImage()
        {
            SetDefaultImage();
        }
        public void SetDefaultImage()
        {
            ImageUrl = "https://placehold.co/300x200/eegddff/white?text=Default";
        }
        public void ChangeName(string newName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(newName, nameof(newName));

            Name = newName;
        }
    }
}