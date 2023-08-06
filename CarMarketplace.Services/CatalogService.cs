namespace CarMarketplace.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using CarMarketplace.Data;
    using CarMarketplace.Services.Contracts;
    using CarMarketplace.Services.Mapping;
    using CarMarketplace.Web.ViewModels.Catalog;
    using System;
    using CarMarketplace.Data.Models;

    public class CatalogService : ICatalogService
    {
        private readonly CarMarketplaceDbContext dbContext;

        public CatalogService(CarMarketplaceDbContext _dbContext)
        {
            this.dbContext = _dbContext;   
        }

        private ICollection<SalePostViewModel> FilterAllSalePosts(ICollection<SalePostViewModel> posts, SearchViewModel model)
        {
            if (model.Make != 0)
            {
                posts = posts.Where(p => p.Car.Make.Id == model.Make).ToArray();
            }
            if (model.ModelName != null)
            {
                posts = posts.Where(p => p.Car.Model.ModelName == model.ModelName).ToArray();
            }
            if (model.ProvinceId != 0)
            {
                posts = posts.Where(p => p.Car.Province.Id == model.ProvinceId).ToArray();
            }

            if (model.FromHorsepower != null && model.ToHorsepower != null)
            {
                posts = posts.Where(p => p.Car.Engine.Horsepower >= model.FromHorsepower && p.Car.Engine.Horsepower <= model.ToHorsepower).ToArray();
            }
            else if (model.FromHorsepower != null)
            {
                posts = posts.Where(p => p.Car.Engine.Horsepower >= model.FromHorsepower).ToArray();
            }
            else if (model.ToHorsepower != null)
            {
                posts = posts.Where(p => p.Car.Engine.Horsepower <= model.ToHorsepower).ToArray();
            }

            if (model.FromKilometers != null && model.ToKilometers != null)
            {
                posts = posts.Where(p => p.Car.Odometer >= model.FromKilometers && p.Car.Odometer <= model.ToKilometers).ToArray();
            }
            else if (model.FromKilometers != null)
            {
                posts = posts.Where(p => p.Car.Odometer >= model.FromKilometers).ToArray();
            }
            else if (model.ToKilometers != null)
            {
                posts = posts.Where(p => p.Car.Odometer <= model.ToKilometers).ToArray();
            }

            if (model.FromYear != null && model.ToYear != null)
            {
                posts = posts.Where(p => p.Car.Year >= model.FromYear && p.Car.Year <= model.ToYear).ToArray();
            }
            else if (model.FromYear != null)
            {
                posts = posts.Where(p => p.Car.Year >= model.FromYear).ToArray();
            }
            else if (model.ToYear != null)
            {
                posts = posts.Where(p => p.Car.Year <= model.ToYear).ToArray();
            }

            if (model.FromPrice != null && model.ToPrice != null)
            {
                posts = posts.Where(p => p.Price >= model.FromPrice && p.Price <= model.ToPrice).ToArray();
            }
            else if (model.FromPrice != null)
            {
                posts = posts.Where(p => p.Price >= model.FromPrice).ToArray();
            }
            else if (model.ToPrice != null)
            {
                posts = posts.Where(p => p.Price <= model.ToPrice).ToArray();
            }

            if (model.EngineFuelType != null)
            {
                posts = posts.Where(p => p.Car.Engine.FuelType == model.EngineFuelType).ToArray();
            }
            if (model.TransmissionType != null)
            {
                posts = posts.Where(p => p.Car.TransmissionType == model.TransmissionType).ToArray();
            }
            if (model.Category != 0)
            {
                posts = posts.Where(p => p.Car.Category.Id == model.Category).ToArray();
            }

            return posts;
        }

        public async Task<ICollection<SalePostViewModel>> GetFilteredSalePostsAsync(SearchViewModel model)
        {
            ICollection<SalePostViewModel> posts = await this.dbContext
                .SalePosts
                .Select(sp => new SalePostViewModel()
                {
                    Car = new CarViewModel()
                    {
                        CarName = sp.Car.Make.Name + " " + sp.Car.Model.ModelName,
                        Make = new CarManufacturerViewModel()
                        {
                            Id = sp.Car.ManufacturerId,
                            Name = sp.Car.Make.Name
                        },
                        Model = new CarModelViewModel()
                        {
                            Id = sp.Car.ModelId,
                            ModelName = sp.Car.Model.ModelName
                        },
                        Category = new CategoryViewModel()
                        {
                            Id = sp.Car.CategoryId,
                            Name = sp.Car.Category.Name
                        },
                        Description = sp.Car.Description,
                        TechnicalSpecificationURL = sp.Car.TechnicalSpecificationURL,
                        Color = sp.Car.Color.Name,
                        EuroStandart = sp.Car.EuroStandart,
                        Odometer = sp.Car.Odometer,
                        Province = new ProvinceViewModel()
                        {
                            Id = sp.Car.ProvinceId,
                            ProvinceName = sp.Car.Province.ProvinceName
                        },
                        VinNumber = sp.Car.VinNumber,
                        TransmissionType = sp.Car.TransmissionType,
                        Year = sp.Car.Year,
                        Engine = new EngineViewModel()
                        {
                            Id = sp.Car.EngineId,
                            Displacement = sp.Car.Engine.Displacement,
                            Horsepower = sp.Car.Engine.Horsepower,
                            FuelType = sp.Car.Engine.FuelType
                        }
                    },
                    Seller = new SellerViewModel()
                    {
                        FirstName = sp.Seller.FirstName,
                        LastName = sp.Seller.LastName,
                        PhoneNumber = sp.Seller.PhoneNumber
                    },
                    PublishDate = sp.PublishDate,
                    ImageUrls = sp.ImageUrls,
                    Price = sp.Price,
                    Id = sp.Id
                })
                .AsNoTracking()
                .ToArrayAsync();

            posts = FilterAllSalePosts(posts, model);

            return posts;
        }

        public async Task<ICollection<SalePostViewModel>> GetLatestSalePostsAsync()
        {
            ICollection<SalePostViewModel> lastPosts = await this.dbContext
                .SalePosts
                .OrderBy(sp => sp.PublishDate)
                .Take(6)
                .Select(sp => new SalePostViewModel()
                {
                    Car = new CarViewModel()
                    {
                        CarName = sp.Car.Make.Name + " " + sp.Car.Model.ModelName,
                        Make = new CarManufacturerViewModel()
                        {
                            Id = sp.Car.ManufacturerId,
                            Name = sp.Car.Make.Name
                        },
                        Model = new CarModelViewModel()
                        {
                            Id = sp.Car.ModelId,
                            ModelName = sp.Car.Model.ModelName
                        },
                        Category = new CategoryViewModel()
                        {
                            Id = sp.Car.CategoryId,
                            Name = sp.Car.Category.Name
                        },
                        Description = sp.Car.Description,
                        TechnicalSpecificationURL = sp.Car.TechnicalSpecificationURL,
                        Color = sp.Car.Color.Name,
                        EuroStandart = sp.Car.EuroStandart,
                        Odometer = sp.Car.Odometer,
                        Province = new ProvinceViewModel()
                        {
                            Id = sp.Car.ProvinceId,
                            ProvinceName = sp.Car.Province.ProvinceName
                        },
                        VinNumber = sp.Car.VinNumber,
                        TransmissionType = sp.Car.TransmissionType,
                        Year = sp.Car.Year,
                        Engine = new EngineViewModel()
                        {
                            Id = sp.Car.EngineId,
                            Displacement = sp.Car.Engine.Displacement,
                            Horsepower = sp.Car.Engine.Horsepower,
                            FuelType = sp.Car.Engine.FuelType
                        }
                    },
                    Seller = new SellerViewModel()
                    {
                        FirstName = sp.Seller.FirstName,
                        LastName = sp.Seller.LastName,
                        PhoneNumber = sp.Seller.PhoneNumber
                    },
                    PublishDate = sp.PublishDate,
                    ImageUrls = sp.ImageUrls,
                    Price = sp.Price,
                    Id = sp.Id
                })
                .ToArrayAsync();

            return lastPosts;
        }

        public async Task<ICollection<CarModelViewModel>> GetModelsByMakeAsync(string make)
        {
            var models = await this.dbContext
                .Models
                .Select(m => new CarModelViewModel()
                {
                    Id = m.Id,
                    ModelName = m.ModelName
                })
                .ToArrayAsync();

            return models;
        }

        public async Task<SalePostViewModel> GetSalePostByIdAsync(Guid postId)
        {
            var postById = await this.dbContext
                .SalePosts
                .Where(x => x.Id == postId)
                .Select(sp => new SalePostViewModel()
                {
                    Car = new CarViewModel()
                    {
                        CarName = sp.Car.Make.Name + " " + sp.Car.Model.ModelName,
                        Make = new CarManufacturerViewModel()
                        {
                            Id = sp.Car.ManufacturerId,
                            Name = sp.Car.Make.Name
                        },
                        Model = new CarModelViewModel()
                        {
                            Id = sp.Car.ModelId,
                            ModelName = sp.Car.Model.ModelName
                        },
                        Category = new CategoryViewModel()
                        {
                            Id = sp.Car.CategoryId,
                            Name = sp.Car.Category.Name
                        },
                        Description = sp.Car.Description,
                        TechnicalSpecificationURL = sp.Car.TechnicalSpecificationURL,
                        Color = sp.Car.Color.Name,
                        EuroStandart = sp.Car.EuroStandart,
                        Odometer = sp.Car.Odometer,
                        Province = new ProvinceViewModel()
                        {
                            Id = sp.Car.ProvinceId,
                            ProvinceName = sp.Car.Province.ProvinceName
                        },
                        VinNumber = sp.Car.VinNumber,
                        TransmissionType = sp.Car.TransmissionType,
                        Year = sp.Car.Year,
                        Engine = new EngineViewModel()
                        {
                            Id = sp.Car.EngineId,
                            Displacement = sp.Car.Engine.Displacement,
                            Horsepower = sp.Car.Engine.Horsepower,
                            FuelType = sp.Car.Engine.FuelType
                        }
                    },
                    Seller = new SellerViewModel()
                    {
                        FirstName = sp.Seller.FirstName,
                        LastName = sp.Seller.LastName,
                        PhoneNumber = sp.Seller.PhoneNumber
                    },
                    PublishDate = sp.PublishDate,
                    ImageUrls = sp.ImageUrls,
                    Price = sp.Price,
                    Id = sp.Id
                })
                .FirstAsync();

            return postById;
                
        }

        public async Task<SearchViewModel> GetSearchViewModelAsync(SearchViewModel model)
        {
            model.Makes = await this.dbContext
                .Manufacturers
                .Select(m => new CarManufacturerViewModel()
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .OrderBy(m => m.Name)
                .ToArrayAsync();

            model.Models = await this.dbContext
                .Models
                .Select(m => new CarModelViewModel()
                {
                    Id = m.Id,
                    ModelName = m.ModelName,
                    ManufacturerName = m.ManufacturerName
                })
                .OrderBy(m => m.ModelName)
                .ToArrayAsync();

            model.Categories = await this.dbContext
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            model.Provinces = await this.dbContext
                .Provinces
                .Select(p => new ProvinceViewModel()
                {
                    Id = p.Id,
                    ProvinceName = p.ProvinceName,
                })
                .ToArrayAsync();

            return model;
        }

        public async Task<AddCarForSaleViewModel> GetAddPostViewModelAsync(AddCarForSaleViewModel viewModel)
        {
            viewModel.Makes = await this.dbContext
                .Manufacturers
                .Select(m => new CarManufacturerViewModel()
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .OrderBy(m => m.Name)
                .ToArrayAsync();

            viewModel.Colors = await this.dbContext
                .Colors
                .Select(c => new ColorViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .ToArrayAsync();

            viewModel.Categories = await this.dbContext
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            viewModel.Provinces = await this.dbContext
                .Provinces
                .Select(p => new ProvinceViewModel()
                {
                    Id = p.Id,
                    ProvinceName = p.ProvinceName,
                })
                .ToArrayAsync();

            return viewModel;
        }

        public async void AddPostAsync(AddCarForSaleViewModel viewModel, Guid sellerId)
        {
            Engine engine = await this.dbContext
                .Engines
                .FirstOrDefaultAsync(e => e.Displacement == viewModel.EngineDisplacement 
                && e.Horsepower == viewModel.EngineHorsePower 
                && e.FuelType == viewModel.EngineFuelType) ?? 
                new Engine()
                {
                    Displacement = viewModel.EngineDisplacement,
                    Horsepower = viewModel.EngineHorsePower,
                    FuelType = viewModel.EngineFuelType
                };

            Category category = await this.dbContext
                .Categories
                .FirstAsync(c => c.Id == viewModel.CategoryId);

            Province province = await this.dbContext
                .Provinces
                .FirstAsync(p => p.Id == viewModel.ProvinceId);

            CarManufacturer make = await this.dbContext
                .Manufacturers
                .FirstAsync(m => m.Id == viewModel.MakeId);

            Color color = await this.dbContext
                .Colors
                .FirstAsync(c => c.Id == viewModel.ColorId);

            Car car = new()
            {
                Make = make,
                Color = color,
                Province = province,
                Category = category,
                Engine = engine,
                City = viewModel.City,
                Description = viewModel.Description,
                VinNumber = viewModel.VinNumber,
                TechnicalSpecificationURL = viewModel.TechnicalSpecificationURL,
                EuroStandart = viewModel.EuroStandart,
                Odometer = viewModel.Odometer,
                TransmissionType = viewModel.TransmissionType,
                Year = viewModel.Year,
            };

            Seller seller = await this.dbContext
                .Sellers
                .FirstAsync(x => x.Id == sellerId);



            //var salePost = new SalePost()
            //{
            //    Seller = seller,
            //    Car = car,
            //    ImageUrls
            //}
        }

        public async void DeletePostAsync(Guid postId)
        {
            var post = await this.dbContext
                .SalePosts
                .FirstAsync(p => p.Id == postId);

            this.dbContext.SalePosts.Remove(post);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
